using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingArea : Interaction
{
    [SerializeField] string roomName;
    [SerializeField] Transform groundTarget;
    [SerializeField] Transform riverTarget;

    protected override bool PerformAction()
    {
        PlayerController player = GameManager.Instance.player;

        if (player.IsInBoat())
        {
            player.transform.position = groundTarget.position;
            player.SetBoat(false);
            EventManager.Instance.RevealRoom(roomName);
        }
        else
        {
            player.transform.position = riverTarget.position;
            player.SetBoat(true);
        }

        return true;
    }
    
    protected override bool CanInteract()
    {
        return GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.BOX_SHIP_GO_NAME);
    }
}
