using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : Interaction
{
    protected override bool PerformAction()
    {
        //GameManager.Instance.inventory.AddObject(InventoryManager.bo);
        return true;
    }
}
