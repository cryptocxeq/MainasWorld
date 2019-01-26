using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingArea : Interaction
{
    protected override void PerformAction()
    {
        Boat boat = GameObject.FindObjectOfType<Boat>();

        PlayerController player = GameManager.Instance.player;

        if (player.IsInBoat())
        {
            boat.ResetParent();
            player.transform.position = transform.position;
            player.SetBoat(false);
            player.LockMovement(false);
        }
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.player.IsInBoat();
    }
}
