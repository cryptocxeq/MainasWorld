﻿using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : Interaction
{
    protected override bool PerformAction()
    {
        string text = "OUCH!! This light is much too bright to be picked up!";
        text = LeanLocalization.GetTranslationText("lighthouseText");
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
