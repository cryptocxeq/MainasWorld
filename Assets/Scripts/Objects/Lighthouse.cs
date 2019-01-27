using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, "OUCH!! This light is much too bright to be picked up!");
        return true;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
