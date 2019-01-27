using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Interaction
{
    [SerializeField] GameObject realForm = null;

    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.SWORD_RULER_GO_NAME))
        {
            Destroy(gameObject);
            Destroy(realForm.gameObject);
            return true;
        }else
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, "I need somthing to cut these exotic plants!");
            return false;
        }

    }

    protected override bool CanInteract()
    {
        return World.Imaginary == GameManager.Instance.swapper.World;
    }
}
