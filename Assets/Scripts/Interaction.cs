using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] SpriteRenderer mouseOverSprite = null;

    bool playerIsNear;

    protected virtual void PerformAction()
    {
        print("the action is activated !");
    }
    protected virtual bool CanInteract()
    {
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        var isHighlighted = false;
        if (!MouseHandler.MouseOnUI() && CanInteract())
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isHighlighted = true;
                    if (Input.GetMouseButtonDown(0) && playerIsNear)
                    {
                        PerformAction();
                    }
                    break;
                }
            }
        }

        mouseOverSprite.gameObject.SetActive(isHighlighted);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerIsNear = false;
    }
}
