using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    private IMenuState currentState;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetState(new MainMenuState());
    }

    void Update()
    {
        currentState?.Update();
    }

    public void SetState(IMenuState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
