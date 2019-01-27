using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interaction
{
    [SerializeField] GameObject boat;
    protected override bool PerformAction()
    {

        EventManager.Instance.ItemPickUp(InventoryManager.BOX_SHIP_GO_NAME);
        Destroy(gameObject);
        Destroy(boat.gameObject);
        /*
        PlayerController player = GameManager.Instance.player;
        if (!player.IsInBoat())
        {
            player.LockMovement(true);
            player.transform.position = transform.position;
            player.SetBoat(true);
        }
        */
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }

}
