using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomDoor : Interaction
{
    protected override void PerformAction()
    {
        this.gameObject.SetActive(false);
        EventManager.Instance.RevealRoom("Corridor");
    }
}
