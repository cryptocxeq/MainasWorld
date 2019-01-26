using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Interaction
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
            player.transform.position = transform.position;
            transform.parent.parent = player.transform;
            player.SetBoat(true);
        }
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swaper.World == World.Imaginary;
    }

    public void ResetParent()
    {
        transform.parent.parent = parent;
    }
}
