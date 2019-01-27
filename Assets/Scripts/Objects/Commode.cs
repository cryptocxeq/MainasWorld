using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commode : Interaction
{
    protected override bool PerformAction()
    {

        EventManager.Instance.ItemPickUp(InventoryManager.RAZOR_STONE_GO_NAME);
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}