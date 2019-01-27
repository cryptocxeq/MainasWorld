using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum DialogSpeaker
    {
        MOTHER,
        MAINA,
        TEDDY,
        PAPER_CLIP,
        BOX_SHIP,
        SWORD_RULER,
        BOSS_KEY,
        RAZOR_STONE,
        TORCH_LIGHT
    }

    [SerializeField]
    private GameObject dialogPanel = null;
    [SerializeField]
    private GameObject inventoryPanel = null;
    [SerializeField]
    private Image avatarImage = null;
    [SerializeField]
    private TMP_Text dialogText = null;

    private InventoryManager inventoryManager;
    private EventManager eventManager;


    [SerializeField]
    private Image inventoryImage1 = null;
    [SerializeField]
    private Image inventoryImage2 = null;
    [SerializeField]
    private Image inventoryImage3 = null;
    [SerializeField]
    private Image inventoryImage4 = null;
    [SerializeField]
    private Image inventoryImage5 = null;
    [SerializeField]
    private Image inventoryImage6 = null;
    [SerializeField]
    private Image inventoryImage7 = null;

    [SerializeField]
    private Sprite MOTHER_SPRITE_REAL = null;
    [SerializeField]
    private Sprite MOTHER_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite MAINA_SPRITE_REAL = null;
    [SerializeField]
    private Sprite MAINA_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite TEDDY_BEAR_SPRITE_REAL = null;
    [SerializeField]
    private Sprite TEDDY_BEAR_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite PAPER_CLIP_KEY_SPRITE_REAL = null;
    [SerializeField]
    private Sprite PAPER_CLIP_KEY_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite BOX_SHIP_SPRITE_REAL = null;
    [SerializeField]
    private Sprite BOX_SHIP_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite SWORD_RULER_SPRITE_REAL = null;
    [SerializeField]
    private Sprite SWORD_RULER_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite RAZOR_STONE_SPRITE_REAL = null;
    [SerializeField]
    private Sprite RAZOR_STONE_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite BOSS_KEY_SPRITE_REAL = null;
    [SerializeField]
    private Sprite BOSS_KEY_SPRITE_IMAGINARY = null;
    [SerializeField]
    private Sprite TORCH_LIGHT_SPRITE_REAL = null;
    [SerializeField]
    private Sprite TORCH_LIGHT_SPRITE_IMAGINARY = null;

    // Start is called before the first frame update
    private void Awake()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        HideDialog();
    }

    private void Start()
    {
        eventManager = EventManager.Instance;
    }

    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);

        PlayerController player = GameManager.Instance.player;
        player.LockMovement(true);
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
        if(inventoryManager.switchAsked)
        {
            inventoryManager.switchAsked = false;
            GameManager.Instance.swapper.ChangeWorld();
            OnWorldSwap();
        }

        if (eventManager)
        {
            eventManager.CloseDialog();   
        }

        var player = GameManager.Instance.player;
        player.LockMovement(false);
    }

    public void CleanDialogText()
    {
        dialogText.text = "";
    }

    public void UpdateDialog(DialogSpeaker dialogSpeaker, string text)
    {
        CleanDialogText();

        switch (dialogSpeaker)
        {
            case DialogSpeaker.MOTHER:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = MOTHER_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = MOTHER_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.MAINA:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = MAINA_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = MAINA_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.TEDDY:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = TEDDY_BEAR_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = TEDDY_BEAR_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.PAPER_CLIP:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = PAPER_CLIP_KEY_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = PAPER_CLIP_KEY_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.BOX_SHIP:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = BOX_SHIP_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = BOX_SHIP_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.SWORD_RULER:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = SWORD_RULER_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = SWORD_RULER_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.RAZOR_STONE:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = RAZOR_STONE_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = RAZOR_STONE_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.BOSS_KEY:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = BOSS_KEY_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = BOSS_KEY_SPRITE_IMAGINARY;
                }
                break;
            case DialogSpeaker.TORCH_LIGHT:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    avatarImage.sprite = TORCH_LIGHT_SPRITE_REAL;
                }
                else
                {
                    avatarImage.sprite = TORCH_LIGHT_SPRITE_IMAGINARY;
                }
                break;
        }
        dialogText.text = text;

        ShowDialog();
    }

    public void ActionInventoryManager(int inventoryPosition)
    {
        inventoryManager.ActionInventoryManager(inventoryPosition);
    }

    public void SetInventoryItemAtPosition(int position, string name)
    {
        Image modifiedImage = null;

        switch(position)
        {
            case 1:
                modifiedImage = inventoryImage1;
                break;
            case 2:
                modifiedImage = inventoryImage2;
                break;
            case 3:
                modifiedImage = inventoryImage3;
                break;
            case 4:
                modifiedImage = inventoryImage4;
                break;
            case 5:
                modifiedImage = inventoryImage5;
                break;
            case 6:
                modifiedImage = inventoryImage6;
                break;
            case 7:
                modifiedImage = inventoryImage7;
                break;
            default:
                Debug.LogError("UIManager - SetInventoryItemAtPosition - Position " + position + " unknown - why the hell we are here?");
                break;
        }

        switch(name)
        {
            case InventoryManager.TEDDY_BEAR_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = TEDDY_BEAR_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = TEDDY_BEAR_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.PAPER_CLIP_KEY_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = PAPER_CLIP_KEY_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = PAPER_CLIP_KEY_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.BOX_SHIP_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = BOX_SHIP_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = BOX_SHIP_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.SWORD_RULER_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = SWORD_RULER_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = SWORD_RULER_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.RAZOR_STONE_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = RAZOR_STONE_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = RAZOR_STONE_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.BOSS_KEY_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = BOSS_KEY_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = BOSS_KEY_SPRITE_IMAGINARY;
                }
                break;
            case InventoryManager.TORCH_LIGHT_GO_NAME:
                if (GameManager.Instance.swapper.World.Equals(World.Real))
                {
                    modifiedImage.sprite = TORCH_LIGHT_SPRITE_REAL;
                }
                else
                {
                    modifiedImage.sprite = TORCH_LIGHT_SPRITE_IMAGINARY;
                }
                break;
            default:
                Debug.LogError("UIManager - SetInventoryItemAtPosition - Object " + name + " unknown - why the hell we are here?");
                break;
        }
    }

    private void OnWorldSwap()
    {
        inventoryManager.OnWorldSwap();
    }
}
