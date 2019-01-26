using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
        EventManager.Instance.OnRoomReveal += (string name) => {
            if (name == this.gameObject.name) {
                this.gameObject.SetActive(true);
            }
        };
    }
}
