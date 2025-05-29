using UnityEngine;

public class MainMenuState : IMenuState
{
    private GameObject menuUI;

    public void Enter()
    {
        menuUI = GameObject.Find("MainMenuUI");
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
