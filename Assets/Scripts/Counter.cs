using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Counter : MonoBehaviour
{
    public int Count = 0;
    Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill()
    {
        Count = Count + 1 ;
        _text.text = $"{Count}";
    }
}
