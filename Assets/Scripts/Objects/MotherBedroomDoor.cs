using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBedroomDoor : Interaction
{
    protected override bool PerformAction()
    {
        var mummyName = GameManager.Instance.swapper.World == World.Real ? "Mummy" : "the witch";
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
            $"That's the door to {mummyName}'s bedroom where she's sleeping. The keys to the house are in " +
            "there, but the door is locked!");
        return false;
    }
}
