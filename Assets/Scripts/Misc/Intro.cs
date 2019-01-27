using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MOTHER, 
            "You're a naughty girl! I told you not to leave the house. To teach you some manners, you're " +
            "grounded and you'll stay in your room until your majority!");
        EventManager.Instance.OnDialogClosed += PlayMainaDialogue;
    }

    private void PlayMainaDialogue()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, 
            "Mummy is really too mean. If only Daddy was still here.... I have to escape to find him!");
        EventManager.Instance.OnDialogClosed -= PlayMainaDialogue;
    }   
}
