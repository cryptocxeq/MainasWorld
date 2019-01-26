using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRuler : Interaction
{
    protected override void PerformAction()
    {
        EventManager.Instance.ItemPickUp(InventoryManager.SWORD_RULER_GO_NAME);
    }

    protected override bool CanInteract()
    {
        return base.CanInteract();
    }
}
