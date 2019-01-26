using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    void Update()
    {
        this.transform.position = target.transform.position;
    }
}
