using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private int currentObjectIndex;
    private Dictionary<int, string> objectPositionInInventory;

    public const string TEDDY_BEAR_GO_NAME = "TeddyBear";
    public const string PAPER_CLIP_KEY_GO_NAME = "PaperClipKey";
    public const string BOX_SHIP_GO_NAME = "BoxShip";
    public const string SWORD_RULER_GO_NAME = "SwordRuler";
    public const string RAZOR_STONE_GO_NAME = "RazorStone";
    public const string BOSS_KEY_GO_NAME = "BossKey";
    public const string TORCH_LIGHT_GO_NAME = "TorchLight";

    private UIManager uiManager;
    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        currentObjectIndex = 0;
        objectPositionInInventory = new Dictionary<int, string>();

        uiManager = GameObject.FindObjectOfType<UIManager>();

        eventManager = EventManager.Instance;
        eventManager.OnItemPickUp += AddObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Add object to inventory
     */
    public void AddObject(string name)
    {
        int objectPosition = InventoryHasObject(name);
        if (objectPosition < 0)
        {
            Debug.Log("Adding object " + name + " in inventory in position " + objectPosition);
            objectPositionInInventory.Add(currentObjectIndex, name);
            currentObjectIndex++;
            AddObjectFeedback(name);
        }
        else
        {
            Debug.LogError("InventoryManager - AddObject - Object " + name + " already in inventory - why the hell we are here?");
        }
    }

    /*
     * Return if we have the object in inventory as a boolean
     */
    public bool InventoryObjectOwned(string name)
    {
        if(InventoryHasObject(name) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
     * Return if we have the object in inventory as its position in inventory
     */
    public int InventoryHasObject(string name)
    {        
        if (objectPositionInInventory.ContainsValue(name))
        {
            int value = objectPositionInInventory.Values.ToList().IndexOf(name);
            return value;
        }
        else
        {
            return -1;
        }
    }

    /*
     * Return name of Inventory object at position if available, else return empty string
     */
    public string GetInventoryObjectName(int position)
    {
        string name = string.Empty;
        objectPositionInInventory.TryGetValue(position, out name);
        return name;
    }
    
    /*
     * Launch action for object at selected position in inventory
     */
    public void ActionInventoryManager(int inventoryPosition)
    {
        string objectName = GetInventoryObjectName(inventoryPosition);
        ActionInventoryManager( objectName);
    }

    private void ActionInventoryManager(string objectName)
    {
        if (objectName != null)
        {
            switch (objectName)
            {
                case TEDDY_BEAR_GO_NAME:
                    ActionTeddyBearClickOnInventory();
                    break;
                case PAPER_CLIP_KEY_GO_NAME:
                    ActionPaperClipKeyClickOnInventory();
                    break;
                case BOX_SHIP_GO_NAME:
                    ActionBoxShipClickOnInventory();
                    break;
                case SWORD_RULER_GO_NAME:
                    ActionSwordRulerClickOnInventory();
                    break;
                case RAZOR_STONE_GO_NAME:
                    ActionRazorStoneClickOnInventory();
                    break;
                case BOSS_KEY_GO_NAME:
                    ActionBossKeyClickOnInventory();
                    break;
                case TORCH_LIGHT_GO_NAME:
                    ActionTorchLightClickOnInventory();
                    break;
                default:
                    Debug.LogError("InventoryManager - ActionInventoryManager - Object " + name + " unknown - why the hell we are here?");
                    break;
            }
        }
        else
        {
            Debug.Log("InventoryManager - ActionInventoryManager - click on empty position ");
        }
    }

    private void AddObjectFeedback(string objectName)
    {
        if (objectName != null)
        {
            switch (objectName)
            {
                case TEDDY_BEAR_GO_NAME:
                    ActionTeddyBearOnAdd();
                    break;
                case PAPER_CLIP_KEY_GO_NAME:
                    ActionPaperClipKeyOnAdd();
                    break;
                case BOX_SHIP_GO_NAME:
                    ActionBoxShipOnAdd();
                    break;
                case SWORD_RULER_GO_NAME:
                    ActionSwordRulerOnAdd();
                    break;
                case RAZOR_STONE_GO_NAME:
                    ActionRazorStoneOnAdd();
                    break;
                case BOSS_KEY_GO_NAME:
                    ActionBossKeyOnAdd();
                    break;
                case TORCH_LIGHT_GO_NAME:
                    ActionTorchLightOnAdd();
                    break;
                default:
                    Debug.LogError("InventoryManager - ActionInventoryManager - Object " + name + " unknown - why the hell we are here?");
                    break;
            }
        }
        else
        {
            Debug.Log("InventoryManager - ActionInventoryManager - click on empty position ");
        }
    }

    #region ClickOnInventory
    private void ActionTeddyBearClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionPaperClipKeyClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionBoxShipClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionSwordRulerClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionRazorStoneClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionBossKeyClickOnInventory()
    {
        throw new NotImplementedException();
    }

    private void ActionTorchLightClickOnInventory()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region OnAdd
    private void ActionTeddyBearOnAdd()
    {
        uiManager.UpdateDialog(UIManager.DialogSpeaker.TEDDY,"Salut je m'appelle Teddy");
    }

    private void ActionPaperClipKeyOnAdd()
    {
        throw new NotImplementedException();
    }

    private void ActionBoxShipOnAdd()
    {
        throw new NotImplementedException();
    }

    private void ActionSwordRulerOnAdd()
    {
        throw new NotImplementedException();
    }

    private void ActionRazorStoneOnAdd()
    {
        throw new NotImplementedException();
    }

    private void ActionBossKeyOnAdd()
    {
        throw new NotImplementedException();
    }

    private void ActionTorchLightOnAdd()
    {
        throw new NotImplementedException();
    }
    #endregion
}
