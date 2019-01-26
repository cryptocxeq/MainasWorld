using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBox : Interaction
{
    protected override void PerformAction()
    {
        GameManager.Instance.inventory.AddObject(InventoryManager.TEDDY_BEAR_GO_NAME);
        // activer dans le monde Imaginaire "TedyBear";
    }

}
