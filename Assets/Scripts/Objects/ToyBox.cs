using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBox : Interaction
{
    protected override bool PerformAction()
    {
        EventManager.Instance.ItemPickUp(InventoryManager.TEDDY_BEAR_GO_NAME);
        // activer dans le monde Imaginaire "TedyBear";
        return true;
    }
}
