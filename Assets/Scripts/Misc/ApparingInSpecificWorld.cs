using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparingInSpecificWorld : MonoBehaviour
{
    [SerializeField] World world = World.Real;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnWorldChange += (World w) => { GetComponent<Collider2D>().enabled = world == w; };
    }

}
