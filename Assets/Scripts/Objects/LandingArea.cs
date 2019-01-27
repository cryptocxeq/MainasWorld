using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingArea : Interaction
{
    protected override bool PerformAction()
    {
        Boat boat = GameObject.FindObjectOfType<Boat>();

        PlayerController player = GameManager.Instance.player;

        if (player.IsInBoat())
        {
            boat.ActivateFollow(false);
            player.transform.position = transform.position;
            player.SetBoat(false);
            player.LockMovement(false);
        }

        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.player.IsInBoat();
    }
}
