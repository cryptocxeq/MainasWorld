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
    public bool switchAsked;

    // Start is called before the first frame update
    void Start()
    {
        currentObjectIndex = 1;
        objectPositionInInventory = new Dictionary<int, string>();

        uiManager = GameObject.FindObjectOfType<UIManager>();

        eventManager = EventManager.Instance;
        eventManager.OnItemPickUp += AddObject;

        switchAsked = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.I))
        {
            DebugFeatureAddAllAvailableObjectsInInventory();
        }
#endif
    }

    /*
     * Add object to inventory
     */
    public void AddObject(string name)
    {
        int objectPosition = InventoryHasObject(name);
        if (objectPosition < 1)
        {
            Debug.Log("Adding object " + name + " in inventory in position " + objectPosition);
            objectPositionInInventory.Add(currentObjectIndex, name);
            currentObjectIndex++;
            AddObjectFeedback(name);
        }
        else
        {
            Debug.LogWarning("InventoryManager - AddObject - Object " + name + " already in inventory");
        }
    }

    /*
     * Return if we have the object in inventory as a boolean
     */
    public bool InventoryObjectOwned(string name)
    {
        if(InventoryHasObject(name) >= 1)
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
        int value = 0;
        string objectName = "";
        foreach(int currentKey in objectPositionInInventory.Keys)
        {
            objectName = "";
            objectPositionInInventory.TryGetValue(currentKey, out objectName);
            if (objectName.Equals(name))
            {
                value = currentKey;
                break;
            }
        }
        //if (objectPositionInInventory.ContainsValue(name))
        //{
        //    int value = objectPositionInInventory.Values.ToList().IndexOf(name);
        //    return value;
        //}
        //else
        //{
        //    return 0;
        //}

        return value;
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
        if (GameManager.Instance.swapper.CantSwapReason != null)
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.TEDDY, GameManager.Instance.swapper.CantSwapReason);
        }
        else
        {
            switchAsked = true;
            
            if (GameManager.Instance.swapper.World.Equals(World.Real))
            {
                uiManager.UpdateDialog(UIManager.DialogSpeaker.TEDDY, 
                    "Maïna, Maïna, let's visit the wonderful imaginary world!");
            }
            else
            {
                uiManager.UpdateDialog(UIManager.DialogSpeaker.TEDDY, 
                    "If you're sure you want to go back to the boring real world...");
            }
        }        
    }

    private void ActionPaperClipKeyClickOnInventory()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.PAPER_CLIP, 
                "An old paper clip that was lying around.");
        }
        else
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.PAPER_CLIP,
                "The key to get out of the room the witch imprisoned me in!");
        }
        
    }

    private void ActionBoxShipClickOnInventory()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.BOX_SHIP,
                "A cardboard box. I like to play with it, imagining it's a boat.");
        }
        else
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.BOX_SHIP,
                "The Esmeralda, my boat. It's unsinkable!");
        }
    }

    private void ActionSwordRulerClickOnInventory()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.SWORD_RULER,
                "That's the ruler Mummy uses to hit me when I've been bad.");
        }
        else
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.SWORD_RULER,
                "Caliburn, the legendary sword. It's got magical powers.");
        }
        
    }

    private void ActionRazorStoneClickOnInventory()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.RAZOR_STONE,
               "Daddy's razor. That's all that's left of him here.");
        }
        else
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.RAZOR_STONE,
                "Daddy's ultra-sharp Cutter 2000. He uses it on all of him adventures.");
        }
    }

    private void ActionBossKeyClickOnInventory()
    {
        uiManager.UpdateDialog(UIManager.DialogSpeaker.BOSS_KEY,
            "The house key! I can finally leave to join Daddy on his latest adventure.");        
    }

    private void ActionTorchLightClickOnInventory()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.TORCH_LIGHT,
                "When mummy punishes me in the cupboard, I use this light to scare monsters away.");
        }
        else
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.TORCH_LIGHT,
                "The light of Eärendil. It will light my way in darkness places when all other lights go out.");
        }        
    }
    #endregion

    #region OnAdd
    private void ActionTeddyBearOnAdd()
    {
        uiManager.UpdateDialog(UIManager.DialogSpeaker.TEDDY,
            "Maïna! I'm so happy to see you. I thought you would leave me in that dreaded toy-box forever.");
        int inventoryPosition = InventoryHasObject(TEDDY_BEAR_GO_NAME);
        uiManager.SetInventoryItemAtPosition(inventoryPosition, TEDDY_BEAR_GO_NAME);

    }

    private void ActionPaperClipKeyOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.PAPER_CLIP,
                "A paper clip? What is it doing here?");
            int inventoryPosition = InventoryHasObject(PAPER_CLIP_KEY_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, PAPER_CLIP_KEY_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }

    private void ActionBoxShipOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.BOX_SHIP,
                "We moved after daddy left, and we still have cardboard boxes lying around.");
            int inventoryPosition = InventoryHasObject(BOX_SHIP_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, BOX_SHIP_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }

    private void ActionSwordRulerOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.SWORD_RULER,
                "My ruler! I never go anywhere without it.");
            int inventoryPosition = InventoryHasObject(SWORD_RULER_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, SWORD_RULER_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }

    private void ActionRazorStoneOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.RAZOR_STONE,
                "Daddy's rasor. Why would he leave without it?");
            int inventoryPosition = InventoryHasObject(RAZOR_STONE_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, RAZOR_STONE_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }

    private void ActionBossKeyOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.BOSS_KEY,
                "The house keys! Quick, let's not wake Mummy up or she's be really mad.");
            int inventoryPosition = InventoryHasObject(BOSS_KEY_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, BOSS_KEY_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }

    private void ActionTorchLightOnAdd()
    {
        if (GameManager.Instance.swapper.World.Equals(World.Real))
        {
            uiManager.UpdateDialog(UIManager.DialogSpeaker.TORCH_LIGHT,
                "Le pouvoir de la lumière!");
            int inventoryPosition = InventoryHasObject(TORCH_LIGHT_GO_NAME);
            uiManager.SetInventoryItemAtPosition(inventoryPosition, TORCH_LIGHT_GO_NAME);
        }
        else
        {
            Debug.LogError("SHOULD NOT HAPPEN");
        }
    }
    #endregion
    

    public void OnWorldSwap()
    {
        foreach (int currentKey in objectPositionInInventory.Keys)
        {
            string name = "";
            objectPositionInInventory.TryGetValue(currentKey, out name);
            uiManager.SetInventoryItemAtPosition(currentKey, name);
        }
    }

    public void DebugFeatureAddAllAvailableObjectsInInventory()
    {
        AddObject(TEDDY_BEAR_GO_NAME);
        AddObject(PAPER_CLIP_KEY_GO_NAME);
        AddObject(BOX_SHIP_GO_NAME);
        AddObject(SWORD_RULER_GO_NAME);
        AddObject(RAZOR_STONE_GO_NAME);
        AddObject(BOSS_KEY_GO_NAME);
        AddObject(TORCH_LIGHT_GO_NAME);
    }
}
