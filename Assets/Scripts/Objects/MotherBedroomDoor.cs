using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBedroomDoor : Interaction
{
    protected override bool PerformAction()
    {
        string realMummyName = "Mummy";
        realMummyName = LeanLocalization.GetTranslationText("realMummyNameText");

        string imaginaryMummyName = "the witch";
        imaginaryMummyName = LeanLocalization.GetTranslationText("imaginaryMummyNameText");

        string mummyName = GameManager.Instance.swapper.World == World.Real ? realMummyName : imaginaryMummyName;

        string motherBedroomDoorPartOneText = "That's the door to ";
        motherBedroomDoorPartOneText = LeanLocalization.GetTranslationText("motherBedroomDoorPartOneText");
        string motherBedroomDoorPartTwoText = "'s bedroom where she's sleeping. The keys to the house are in there, but the door is locked!";
        motherBedroomDoorPartTwoText = LeanLocalization.GetTranslationText("motherBedroomDoorPartTwoText");

        string text = motherBedroomDoorPartOneText + mummyName + motherBedroomDoorPartTwoText;
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
        return false;
    }
}
