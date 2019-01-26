using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public delegate void WorldChange(World world);
    public event WorldChange OnWorldChange;

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
}