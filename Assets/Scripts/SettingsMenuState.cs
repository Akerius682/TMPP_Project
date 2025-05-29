using UnityEngine;

public class SettingsMenuState : IMenuState
{
    private GameObject menuUI;

    public void Enter()
    {
        menuUI = GameObject.Find("SettingsMenuUI");
        if (menuUI != null) menuUI.SetActive(true);
    }

    public void Update()
    {
    }

    public void Exit()
    {
        if (menuUI != null) menuUI.SetActive(false);
    }
}
