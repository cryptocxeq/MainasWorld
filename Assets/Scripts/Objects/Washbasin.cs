using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washbasin : Interaction
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.RAZOR_STONE_GO_NAME))
        {
            string text = "Congratulations princess! Here is your clue: I am taller than the tallest building, and my shining light warms out hearts and lights our path.";
            text = LeanLocalization.GetTranslationText("washbasinFoundText");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.FATHER, text);
        }
        else
        {
            string text = "Hello princess. Find me the razor stone and I will tell you where you can find what you are looking for!";
            text = LeanLocalization.GetTranslationText("washbasinFindText");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.FATHER, text);
        }        
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
