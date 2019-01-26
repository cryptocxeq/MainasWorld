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

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDialog()
    {
        dialogPanel.SetActive(true);
    }

    public void hideDialog()
    {
        dialogPanel.SetActive(false);
    }

    public void UpdateDialog(DialogSpeaker dialogSpeaker, string text)
    {
        switch(dialogSpeaker)
        {
            case DialogSpeaker.MAINA:
                avatarImage.sprite = mainaAvatarSprite;
                break;
            case DialogSpeaker.TEDDY:
                avatarImage.sprite = teddyAvatarSprite;
                break;
        }
        dialogText.text = text;
    }

    public void ActionInventoryManager(int inventoryPosition)
    {
        inventoryManager.ActionInventoryManager(inventoryPosition);
    }
}
