using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoor : Interaction
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.PAPER_CLIP_KEY_GO_NAME) &&
            GameManager.Instance.swapper.World == World.Imaginary)
        {
            this.gameObject.SetActive(false);
            EventManager.Instance.RevealRoom("Corridor");
            return true;
        }
        else
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
                "Mummy locked the door to my room. I need to get out!");
            return false;
        }
    }
}
