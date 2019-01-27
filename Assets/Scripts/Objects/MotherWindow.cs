using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherWindow : Interaction
{
    [SerializeField] string roomName = null;
    [SerializeField] Transform targetPos = null;

    protected override bool PerformAction()
    {
        PlayerController player = GameManager.Instance.player;

        player.transform.position = targetPos.position;
        EventManager.Instance.RevealRoom(roomName);

        return false;
    }
}
