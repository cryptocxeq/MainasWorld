using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : Interaction
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.TORCH_LIGHT_GO_NAME))
        {
            this.gameObject.SetActive(true);
            EventManager.Instance.RevealRoom("SecretPassage");
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override bool CanInteract()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.TORCH_LIGHT_GO_NAME))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
