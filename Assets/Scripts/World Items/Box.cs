using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interaction
{
    Transform parent;

    void Start()
    {
        parent = transform.parent.parent;
    }

    protected override void PerformAction()
    {
        PlayerController player = GameManager.Instance.player;
        if (!player.IsInBoat())
        {
            player.LockMovement(true);
            player.transform.position = transform.position;
            transform.parent.parent = player.transform;
            player.SetBoat(true);
        }
    }

    protected override bool CanInteract()
    {
        return !GameManager.Instance.swaper.isImaginaryWorld;
    }

    public void ResetParent()
    {
        transform.parent.parent = parent;
    }
}
