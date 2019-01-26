using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwaper : MonoBehaviour
{
    [SerializeField] private GameObject realityWorld;
    [SerializeField] private GameObject imaginaryWorld;

    public bool isImaginaryWorld;
    public bool canSwap;

    int basicMask;

    // Start is called before the first frame update
    void Start()
    {
        canSwap = true;
        basicMask = Camera.main.cullingMask;
        ChangeWorld();

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
        if (!canSwap)
            return;

        isImaginaryWorld = !isImaginaryWorld;

        //*
        realityWorld.SetActive(!isImaginaryWorld);
        imaginaryWorld.SetActive(isImaginaryWorld);
        //*/
        if (isImaginaryWorld)
            Camera.main.cullingMask = basicMask | (1 << LayerMask.NameToLayer("Imaginary"));
        else
            Camera.main.cullingMask = basicMask | (1 << LayerMask.NameToLayer("Reality"));
        //*/

        GameManager.Instance.player.LockMovement(GameManager.Instance.player.IsInBoat() && !isImaginaryWorld);
    }
}
