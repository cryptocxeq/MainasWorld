using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MOTHER, 
            "Tu es une vilaine fille Maïna ! Je t'avais prévenu de ne pas t'aventurer dehors. Pour t'apprendre " +
            "l'obéissance, tu resteras dans ta chambre jusqu'à ta majorité !");
    }
}
