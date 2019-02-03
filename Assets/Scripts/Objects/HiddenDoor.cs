using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : Interaction
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.TORCH_LIGHT_GO_NAME))
        {
            this.gameObject.SetActive(false);
            EventManager.Instance.RevealRoom("Balcony");
            string text = "Darkness fades with the light and the monsters go away.";
            text = LeanLocalization.GetTranslationText("hiddenDoorPerformActionRealText");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
            return true;
        }
        else
        {
            string text = "It is too dark here. I can't go alone!";
            text = LeanLocalization.GetTranslationText("hiddenDoorPerformActionRealNoTorchText");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
            return false;
        }
    }

    protected override bool CanInteract()
    {
         return true;
    }
}
