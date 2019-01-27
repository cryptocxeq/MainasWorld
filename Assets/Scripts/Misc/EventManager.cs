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
    public event ItemClick OnItemPickUp;
    public delegate void DialogClosed();
    public event DialogClosed OnDialogClosed;
    public delegate void HighlightChange(bool isHighlighted);
    public event HighlightChange OnHighlight;

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

    public void ItemPickUp(string name)
    {
        if (OnItemPickUp != null)
        {
            OnItemPickUp(name);
        }
    }

    public void CloseDialog()
    {
        if (OnDialogClosed != null)
        {
            OnDialogClosed();
        }
    }

    public void Highlight(bool isHighlighted)
    {
        if (OnHighlight != null)
        {
            OnHighlight(isHighlighted);
        }
    }
}