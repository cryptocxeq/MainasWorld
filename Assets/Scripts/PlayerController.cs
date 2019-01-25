using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 target;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get target position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                target = hit.point;
            }
            else
            {
                target = transform.position;
            }

        }

        // Move to target in strait line
        if (target != transform.position)
        {
            transform.right = target - transform.position;
            //transform.LookAt(target);
            float dist = Vector3.Distance(transform.position, target);
            if (dist > speed * Time.deltaTime)
                body.velocity = transform.right * speed;
            else
            {
                transform.position = target;
                body.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        target = transform.position;
    }
}
