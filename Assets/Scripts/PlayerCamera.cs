using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Player player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        offset = transform.position - player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
