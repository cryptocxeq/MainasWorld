using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBedroomDesk : Interaction
{
    protected override bool PerformAction()
    {
        string text = "Yeah! The key to freedom!";
        text = LeanLocalization.GetTranslationText("motherBedroomPerformActionRealText");
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
        EventManager.Instance.ItemPickUp(InventoryManager.BOSS_KEY_GO_NAME);
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}