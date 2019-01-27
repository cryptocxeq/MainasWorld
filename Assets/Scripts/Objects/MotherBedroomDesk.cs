using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBedroomDesk : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
           "Yeah! The key to freedom!");
        EventManager.Instance.ItemPickUp(InventoryManager.BOSS_KEY_GO_NAME);
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}