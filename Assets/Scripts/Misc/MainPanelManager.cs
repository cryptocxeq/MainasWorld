using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel = null;
    [SerializeField]
    private GameObject creditsPanel = null;

    public void DisplayMainPanel()
    {
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void DisplayCreditsPanel()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
