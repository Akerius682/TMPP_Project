using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class MenuUIController : MonoBehaviour
{
    public MenuButton playButton;
    public MenuButton settingsButton;
    public MenuButton exitButton;
    public MenuButton backButton;

    void Start()
    {
        if (playButton != null)
            playButton.OnClicked += OnPlayClicked;

        if (settingsButton != null)
            settingsButton.OnClicked += OnSettingsClicked;

        if (exitButton != null)
            exitButton.OnClicked += OnExitClicked;

        if (backButton != null)
            backButton.OnClicked += OnBackClicked;
    }

    void OnPlayClicked()
    {
        UnityEngine.Debug.Log("Play clicked! Launching Game...");
        GameObject.Find("MainMenuUI").SetActive(false);
        
    }

    void OnSettingsClicked()
    {
        MenuManager.Instance.SetState(new SettingsMenuState());
    }

    void OnExitClicked()
    {
        UnityEngine.Application.Quit();
    }

    void OnBackClicked()
    {
        MenuManager.Instance.SetState(new MainMenuState());
    }
}
