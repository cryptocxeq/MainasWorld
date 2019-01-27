using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : Interaction
{
    protected override bool PerformAction()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, "The sofa is in the way!");
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }


}
