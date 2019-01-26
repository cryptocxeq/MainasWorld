using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public delegate void WorldChange(World world);
    public event WorldChange OnWorldChange;
    public delegate void RoomReveal(string name);
    public event RoomReveal OnRoomReveal;

    public void Start()
    {
        Instance = this;
    }

    public void DidChangeWorld(World world)
    {
        if (OnWorldChange != null)
        {
            OnWorldChange(world);
        }
    }

    public void DidRevealRoom(string name)
    {
        if (OnRoomReveal != null)
        {
            OnRoomReveal(name);
        }
    }
}