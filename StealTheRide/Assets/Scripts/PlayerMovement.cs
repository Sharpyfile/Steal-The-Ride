using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float xSpeed = 2f;
    public float ySpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            player.Translate(0,ySpeed, 0);
        }
        if (Input.GetKey("s"))
        {
            player.Translate(0,-ySpeed,0);
        }
        if (Input.GetKey("a"))
        {
            player.Translate(-xSpeed,0,0);
        }
        if (Input.GetKey("d"))
        {
            player.Translate(+xSpeed, 0, 0);
        }
    }
}
