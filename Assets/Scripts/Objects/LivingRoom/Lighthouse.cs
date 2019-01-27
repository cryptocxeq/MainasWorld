using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, "Aïe!! Cette lumière est trop chaude pour être récupérée...");
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
