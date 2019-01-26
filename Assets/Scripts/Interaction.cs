using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Interaction : MonoBehaviour
{
    static readonly Color HighlightTint = new Color(1f, 1f, 0.5f);

    [SerializeField] private bool interactsOnce = true;
    [SerializeField] private bool debugMode = false;
    private bool playerIsNear;
    private bool hasInteracted = false;
    private SpriteRenderer spriteRenderer;

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
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (interactsOnce && hasInteracted)
        {
            SetHighlighted(false);
            return;
        }

        var isHighlighted = false;
        if (!MouseHandler.MouseOnUI() && CanInteract())
        {
            var hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (var hit in hits)
            {
                if (!hit.collider || hit.collider.gameObject != gameObject) continue;
                
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

        if (!isHighlighted)
        {
            GameManager.Instance.SelectedObject = null;
        }

        SetHighlighted(isHighlighted);
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
        spriteRenderer.color = isHighlighted ? Interaction.HighlightTint : Color.white;
    }
}
