using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public event Action OnClicked;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClicked?.Invoke());
    }
}
