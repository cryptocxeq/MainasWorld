using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Interaction
{
    [SerializeField] GameObject realForm;

    protected override bool PerformAction()
    {
        Destroy(gameObject);
        Destroy(realForm.gameObject);

        return true;
    }

    protected override bool CanInteract()
    {
        return World.Imaginary == GameManager.Instance.swapper.World && GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.SWORD_RULER_GO_NAME);
    }
}
