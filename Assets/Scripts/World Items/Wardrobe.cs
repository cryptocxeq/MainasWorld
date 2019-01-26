using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : Interaction
{
    protected override bool PerformAction()
    {
        EventManager.Instance.ItemPickUp(InventoryManager.PAPER_CLIP_KEY_GO_NAME);
        return true;
    }

    protected override bool CanInteract()
    {
        return base.CanInteract();
    }
}
