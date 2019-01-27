using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washbasin : Interaction
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.RAZOR_STONE_GO_NAME))
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.FATHER,
               "Congratulations princess! Here is your clue: I am taller than the tallest building, and my shining light warms out hearts and lights our path.");
        }
        else
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.FATHER,
               "Hello princess. Find me the razor stone and I will tell you where you can find what you are looking for!");
        }        
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
