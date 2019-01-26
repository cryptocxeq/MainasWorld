using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImaginaryPlush : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int distance;

    PlayerController player;
    List<Vector3> positions;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(positions.Count < distance || player.transform.position != positions[positions.Count-1])
            positions.Add(player.transform.position);

        if(positions.Count > distance)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
    }
}
