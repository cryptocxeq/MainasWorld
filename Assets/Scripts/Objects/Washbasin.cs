using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washbasin : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.FATHER,
            "Hello princess. Find me the razor stone and I will tell you where you can find what you are looking for!");
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Imaginary;
    }
}
