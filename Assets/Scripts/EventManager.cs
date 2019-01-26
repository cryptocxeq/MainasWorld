using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public delegate void WorldChange(World world);
    public event WorldChange OnWorldChange;
    public delegate void RoomReveal(string name);
    public event RoomReveal OnRoomReveal;
    public delegate void ItemClick(string name);
    public event ItemClick OnItemClick;

    public void Start()
    {
        Instance = this;
    }

    public void ChangeWorld(World world)
    {
        if (OnWorldChange != null)
        {
            OnWorldChange(world);
        }
    }

    public void RevealRoom(string name)
    {
        if (OnRoomReveal != null)
        {
            OnRoomReveal(name);
        }
    }

    public void ClickItem(string name)
    {
        if (OnItemClick != null)
        {
            OnItemClick(name);
        }
    }
}