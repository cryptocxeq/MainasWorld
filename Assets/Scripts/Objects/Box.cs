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

    protected override bool PerformAction()
    {
        PlayerController player = GameManager.Instance.player;
        if (!player.IsInBoat())
        {
            player.LockMovement(true);
            player.transform.position = transform.position;
            transform.parent.parent = player.transform;
            player.SetBoat(true);
        }

        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }

    public void ResetParent()
    {
        transform.parent.parent = parent;
    }
}
