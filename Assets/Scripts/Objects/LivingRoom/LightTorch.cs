using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorch : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.inventory.AddObject(InventoryManager.TORCH_LIGHT_GO_NAME);

        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}
