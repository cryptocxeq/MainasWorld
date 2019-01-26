using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : Interaction
{
    protected override void PerformAction()
    {
        print("The door is initialy locked. Send an answer depending of the inventory.");
    }
}
