using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Interaction
{
    [SerializeField] Follower follower;
    protected override bool PerformAction()
    {
        PlayerController player = GameManager.Instance.player;

        if (!player.IsInBoat())
        {
            player.transform.position = transform.position;
            player.SetBoat(true);
            ActivateFollow(true);
        }

        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }

    public void ActivateFollow(bool value)
    {
        follower.enabled = value;
    }
}
