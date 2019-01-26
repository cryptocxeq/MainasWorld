using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRuler : Interaction
{
    protected override bool PerformAction()
    {
        EventManager.Instance.ItemPickUp(InventoryManager.SWORD_RULER_GO_NAME);
        return true;
    }

    protected override bool CanInteract()
    {
        return base.CanInteract();
    }
}
