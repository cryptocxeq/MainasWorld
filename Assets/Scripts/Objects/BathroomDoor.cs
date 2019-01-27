using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : Interaction
{
    protected override bool PerformAction()
    {
        var roomName = GameManager.Instance.swapper.World == World.Real ? "bathroom" : "ice cave";
        var mummyName = GameManager.Instance.swapper.World == World.Real ? "Mummy" : "the witch";
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
            $"That's the door to the {roomName} but {mummyName} locks it so I can't go in.");
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}
