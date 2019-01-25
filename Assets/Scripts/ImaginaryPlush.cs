using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImaginaryPlush : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] float speed;

    bool following;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            transform.right = player.transform.position - transform.position;
            transform.position += transform.right * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        following = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        following = true;
    }
}
