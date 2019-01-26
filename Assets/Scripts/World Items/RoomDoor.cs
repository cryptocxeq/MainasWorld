using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : Interaction
{
    protected override void PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.PAPER_CLIP_KEY_GO_NAME))
        {
            if (GameManager.Instance.swaper.World == World.Imaginary)
            {
                print("OPEN THE DOOR");
            } else
            {
                print("CAN'T OPEN THE DOOR");
            }
        }
        else
        {
            print("THE DOOR IS LOCKED");
        }
    }

    protected override bool CanInteract()
    {
        return base.CanInteract();
    }
}
