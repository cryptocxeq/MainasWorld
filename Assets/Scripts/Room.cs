using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);

        var roomName = this.gameObject.name.Split('-')[1];
        EventManager.Instance.OnRoomReveal += (string name) => {
            if (name == roomName) {
                this.gameObject.SetActive(true);
            }
        };
    }
}
