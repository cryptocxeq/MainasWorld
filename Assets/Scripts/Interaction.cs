﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Interaction : MonoBehaviour
{
    static Color highlightTint = new Color(1f, 1f, 0.5f);

    [SerializeField] private bool interactsOnce = true;
    [SerializeField] private bool debugMode = false;
    private bool playerIsNear;
    private bool hasInteracted = false;

    protected virtual bool PerformAction()
    {
        print("the action is activated !");
        return false;
    }
    protected virtual bool CanInteract()
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactsOnce && hasInteracted)
        {
            SetHighlighted(false);
            return;
        }

        var isHighlighted = false;
        if (!MouseHandler.MouseOnUI() && CanInteract())
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isHighlighted = true;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (playerIsNear)
                        {
                            GameManager.Instance.SelectedObject = null;
                            hasInteracted = PerformAction();
                        }
                        else
                        {
                            GameManager.Instance.SelectedObject = this;
                        }
                    }

                    break;
                }
            }
        }

        SetHighlighted(isHighlighted);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (debugMode)
            {
                Debug.Log("OnCollisionEnter");
            }

            if (GameManager.Instance.SelectedObject == this)
            {
                GameManager.Instance.SelectedObject = null;
                hasInteracted = PerformAction();
            }

            playerIsNear = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (debugMode)
            {
                Debug.Log("OnCollisionExit");
            }

            playerIsNear = false;
        }
    }

    private void SetHighlighted(bool isHighlighted)
    {
        this.GetComponent<SpriteRenderer>().color = isHighlighted ? Interaction.highlightTint : Color.white;
    }
}
