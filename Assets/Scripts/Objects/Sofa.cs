using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : Interaction
{
    protected override bool PerformAction()
    {
        string text = "The sofa is in the way!";
        text = LeanLocalization.GetTranslationText("sofaPerformActionText");
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }


}
