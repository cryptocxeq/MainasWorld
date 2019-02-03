using Lean.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private void Start()
    {
        string text = "You're a naughty girl! I told you not to leave the house. To teach you some manners, you're grounded and you'll stay in your room until your majority!";
        text = LeanLocalization.GetTranslationText("motherIntroText");
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MOTHER, text);
        EventManager.Instance.OnDialogClosed += PlayMainaDialogue;
    }

    private void PlayMainaDialogue()
    {
        string text = "Mummy is really too mean. If only Daddy was still here.... I have to escape to find him!";
        text = LeanLocalization.GetTranslationText("mainaMotherIntroText");
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
        EventManager.Instance.OnDialogClosed -= PlayMainaDialogue;
    }   
}
