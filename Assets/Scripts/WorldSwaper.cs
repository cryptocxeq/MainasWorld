using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwaper : MonoBehaviour
{
    [SerializeField] private GameObject realityWorld;
    [SerializeField] private GameObject imaginaryWorld;

    bool imaginationActivated;
    int basicMask;

    // Start is called before the first frame update
    void Start()
    {
        basicMask = Camera.main.cullingMask;

        //Camera.main.cullingMask = basicMask | (1 << LayerMask.NameToLayer("Imaginary")) | (1 << LayerMask.NameToLayer("Reality"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeWorld();
        }
    }

    public void ChangeWorld()
    {
        imaginationActivated = !imaginationActivated;

        /*
        realityWorld.SetActive(!imaginationActivated);
        imaginaryWorld.SetActive(imaginationActivated);
        /*/
        if (imaginationActivated)
            Camera.main.cullingMask = basicMask | (1 << LayerMask.NameToLayer("Imaginary"));
        else
            Camera.main.cullingMask = basicMask | (1 << LayerMask.NameToLayer("Reality"));
        //*/
    }
}
