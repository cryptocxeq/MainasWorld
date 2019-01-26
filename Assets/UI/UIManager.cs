using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum DialogSpeaker
    {
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
    private Sprite mainaAvatarSprite = null;
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
    private Sprite TEDDY_BEAR_SPRITE = null;
    [SerializeField]
    private Sprite PAPER_CLIP_KEY_SPRITE = null;
    [SerializeField]
    private Sprite BOX_SHIP_SPRITE = null;
    [SerializeField]
    private Sprite SWORD_RULER_SPRITE = null;
    [SerializeField]
    private Sprite RAZOR_STONE_SPRITE = null;
    [SerializeField]
    private Sprite BOSS_KEY_SPRITE = null;
    [SerializeField]
    private Sprite TORCH_LIGHT_SPRITE = null;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();

        eventManager = EventManager.Instance;
        //eventManager.OnItemClick += AddObject;

        HideDialog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryPanel.SetActive(false);
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
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
            case DialogSpeaker.MAINA:
                avatarImage.sprite = mainaAvatarSprite;
                break;
            case DialogSpeaker.TEDDY:
                avatarImage.sprite = TEDDY_BEAR_SPRITE;
                break;
            case DialogSpeaker.PAPER_CLIP:
                avatarImage.sprite = PAPER_CLIP_KEY_SPRITE;
                break;
            case DialogSpeaker.BOX_SHIP:
                avatarImage.sprite = BOX_SHIP_SPRITE;
                break;
            case DialogSpeaker.SWORD_RULER:
                avatarImage.sprite = SWORD_RULER_SPRITE;
                break;
            case DialogSpeaker.RAZOR_STONE:
                avatarImage.sprite = RAZOR_STONE_SPRITE;
                break;
            case DialogSpeaker.BOSS_KEY:
                avatarImage.sprite = BOSS_KEY_SPRITE;
                break;
            case DialogSpeaker.TORCH_LIGHT:
                avatarImage.sprite = TORCH_LIGHT_SPRITE;
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
            default:
                Debug.LogError("UIManager - SetInventoryItemAtPosition - Position " + position + " unknown - why the hell we are here?");
                break;
        }

        switch(name)
        {
            case InventoryManager.TEDDY_BEAR_GO_NAME:
                modifiedImage.sprite = TEDDY_BEAR_SPRITE;
                break;
            case InventoryManager.PAPER_CLIP_KEY_GO_NAME:
                modifiedImage.sprite = PAPER_CLIP_KEY_SPRITE;
                break;
            case InventoryManager.BOX_SHIP_GO_NAME:
                modifiedImage.sprite = BOX_SHIP_SPRITE;
                break;
            case InventoryManager.SWORD_RULER_GO_NAME:
                modifiedImage.sprite = SWORD_RULER_SPRITE;
                break;
            case InventoryManager.RAZOR_STONE_GO_NAME:
                modifiedImage.sprite = RAZOR_STONE_SPRITE;
                break;
            case InventoryManager.BOSS_KEY_GO_NAME:
                modifiedImage.sprite = BOSS_KEY_SPRITE;
                break;
            case InventoryManager.TORCH_LIGHT_GO_NAME:
                modifiedImage.sprite = TORCH_LIGHT_SPRITE;
                break;
            default:
                Debug.LogError("UIManager - SetInventoryItemAtPosition - Object " + name + " unknown - why the hell we are here?");
                break;
        }
    }
}
