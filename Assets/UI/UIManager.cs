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
        TEDDY
    }

    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private Image avatarImage;
    [SerializeField]
    private Sprite mainaAvatarSprite;
    [SerializeField]
    private Sprite teddyAvatarSprite;
    [SerializeField]
    private TMP_Text dialogText;

    private InventoryManager inventoryManager;
    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();

        eventManager = EventManager.Instance;
        //eventManager.OnItemClick += AddObject;
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
                avatarImage.sprite = teddyAvatarSprite;
                break;
        }
        dialogText.text = text;

        ShowDialog();
    }

    public void ActionInventoryManager(int inventoryPosition)
    {
        inventoryManager.ActionInventoryManager(inventoryPosition);
    }
}
