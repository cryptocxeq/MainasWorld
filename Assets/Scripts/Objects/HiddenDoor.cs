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
            EventManager.Instance.RevealRoom("Balcony");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
               "Darkness fades with the light and the monsters go away.");
            return true;
        }
        else
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
               "It is too dark here. I can't go alone!");
            return false;
        }
    }

    protected override bool CanInteract()
    {
         return true;
    }
}
