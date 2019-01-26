using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Vector3 target;
    private Rigidbody2D body;
    private Animator anim;
    private bool isInBoat;
    private bool isMovementLocked;

    public void SetBoat(bool value)
    {
        isInBoat = value;
        target = transform.position;
    }

    public bool IsInBoat()
    {
        return isInBoat;
    }

    public void LockMovement(bool locked)
    {
        isMovementLocked = locked;
    }

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isMovementLocked = false;
        target = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMovementLocked)
        {
            target = transform.position;
            body.velocity = Vector2.zero;
            return;
        }

        if (!MouseHandler.MouseOnUI())
        {
            if (GameManager.Instance.SelectedObject != null)
                target = GameManager.Instance.SelectedObject.transform.position;

            if (Input.GetMouseButton(0))
            {
                // Get target position
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                target = Physics.Raycast(ray, out hit) ? hit.point : transform.position;
            }
            else if (Input.GetMouseButtonUp(0) && !GameManager.Instance.SelectedObject)
            {
                target = transform.position;
                body.velocity = Vector2.zero;
            }
        }

        // Move to target in strait line
        if (target != transform.position)
        {
            //transform.right = target - transform.position;
            var direction = (target - transform.position).normalized;
            //transform.LookAt(target);
            var dist = Vector3.Distance(transform.position, target);
            if (dist > speed * Time.deltaTime)
                body.velocity = direction * speed;
            else
            {
                transform.position = target;
                body.velocity = Vector2.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            var mousePosition = Input.mousePosition;
            if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x > Screen.width || mousePosition.y > Screen.height)
            {
                transform.position = target;
                body.velocity = Vector2.zero;
            }
        }

        anim.SetBool("walking", body.velocity != Vector2.zero);
        Vector2 dir = body.velocity.normalized;
        if (dir.y > 0.7f)
        {
            anim.SetBool("top", true);
            anim.SetBool("down", false);
            anim.SetBool("leftright", false);
        }
        if (dir.y < -0.7f)
        {
            anim.SetBool("top", false);
            anim.SetBool("down", true);
            anim.SetBool("leftright", false);
        }
        else if (dir.x != 0f)
        {
            anim.SetBool("top", false);
            anim.SetBool("down", false);
            anim.SetBool("leftright", true);
        }
        GetComponent<SpriteRenderer>().flipX = body.velocity.x > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = transform.position;
        body.velocity = Vector2.zero;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        target = transform.position;
        body.velocity = Vector2.zero;
    }
}
