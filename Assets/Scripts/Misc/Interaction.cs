using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private bool interactsOnce = true;
    [SerializeField] private bool debugMode = false;
    [SerializeField] private Color highlightTint = new Color(1f, 1f, 0.5f);
    private bool playerIsNear;
    private bool hasInteracted = false;
    private bool isHighlighted = false;
    private SpriteRenderer[] spriteRenderers;

    protected virtual bool PerformAction()
    {
        print("the action is activated !");
        return false;
    }
    protected virtual bool CanInteract()
    {
        return true;
    }

    private void Start()
    {
        spriteRenderers = this.GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {

        if (interactsOnce && hasInteracted)
        {
            SetHighlighted(false);
            return;
        }

        var isMouseOver = false;
        if (!MouseHandler.MouseOnUI() && CanInteract())
        {            
            var touchedHit = Physics2D
                .RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)
                .Select((h) => (RaycastHit2D?)h)
                .FirstOrDefault((h) => h?.collider.gameObject == gameObject);
            isMouseOver = touchedHit != null;

            if (isMouseOver && Input.GetMouseButtonDown(0))
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
        }

        if (!isMouseOver && GameManager.Instance.SelectedObject == this && Input.GetMouseButton(0))
        {
            GameManager.Instance.SelectedObject = null;
        }
        
        SetHighlighted(isMouseOver && !GameManager.Instance.player.IsMovementLocked);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        if (debugMode)
        {
            Debug.Log("OnCollisionExit");
        }

        playerIsNear = false;
    }

    private void SetHighlighted(bool isHighlighted)
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = isHighlighted ? highlightTint : Color.white;
        }

        if (this.isHighlighted && !isHighlighted)
        {
            EventManager.Instance.Highlight(false);
        }
        else if (!this.isHighlighted && isHighlighted)
        {
            EventManager.Instance.Highlight(true);
        }
        
        this.isHighlighted = isHighlighted;
    }
}
