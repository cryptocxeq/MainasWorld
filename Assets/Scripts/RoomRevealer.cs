using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRevealer : Interaction
{
    [SerializeField] private string roomName = "";

    protected override void PerformAction()
    {
        EventManager.Instance.DidRevealRoom(roomName);
    }
}
