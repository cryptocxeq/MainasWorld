using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : Interaction
{
    protected override bool PerformAction()
    {
        string bathroomRealNameText = "bathroom";
        bathroomRealNameText = LeanLocalization.GetTranslationText("bathroomRealNameText");

        string bathroomImaginaryNameText = "ice cave";
        bathroomImaginaryNameText = LeanLocalization.GetTranslationText("bathroomImaginaryNameText");

        string roomName = GameManager.Instance.swapper.World == World.Real ? bathroomRealNameText : bathroomImaginaryNameText;
        
        string realMummyName = "Mummy";
        realMummyName = LeanLocalization.GetTranslationText("realMummyNameText");

        string imaginaryMummyName = "the witch";
        imaginaryMummyName = LeanLocalization.GetTranslationText("imaginaryMummyNameText");

        var mummyName = GameManager.Instance.swapper.World == World.Real ? realMummyName : imaginaryMummyName;

        string bathroomDoorPartOneText = "That's the door to the ";
        bathroomDoorPartOneText = LeanLocalization.GetTranslationText("bathroomDoorPartOneText");
        string bathroomDoorPartTwoText = " but ";
        bathroomDoorPartTwoText = LeanLocalization.GetTranslationText("bathroomDoorPartTwoText");
        string bathroomDoorPartThreeText = " locks it so I can't go in.";
        bathroomDoorPartThreeText = LeanLocalization.GetTranslationText("bathroomDoorPartThreeText");

        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA,
            bathroomDoorPartOneText + roomName + bathroomDoorPartTwoText + mummyName + bathroomDoorPartThreeText);
        return false;
    }

    protected override bool CanInteract()
    {
        return GameManager.Instance.swapper.World == World.Real;
    }
}
