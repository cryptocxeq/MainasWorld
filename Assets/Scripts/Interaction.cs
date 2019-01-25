using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] SpriteRenderer defaultSprite;
    [SerializeField] SpriteRenderer mouseOverSprite;

    bool playerIsNear;

    protected virtual void PerformAction()
    {
        print("the action is activated !");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                mouseOverSprite.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    PerformAction();
                }
            }
            else
                mouseOverSprite.gameObject.SetActive(false);
        }
        else
            mouseOverSprite.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNear = false;
    }
}
