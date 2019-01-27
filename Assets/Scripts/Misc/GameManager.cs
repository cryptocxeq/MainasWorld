using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player;
    public WorldSwapper swapper;
    public InventoryManager inventory;
    public UIManager ui;
    public Interaction SelectedObject { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.E))
        {
            var rooms = swapper.GetComponentsInChildren<Room>(true);
            foreach (var room in rooms)
            {
                room.gameObject.SetActive(true);
            }
        }
        #endif
    }
}
