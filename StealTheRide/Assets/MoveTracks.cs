using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTracks : MonoBehaviour
{
    public float trackSpeed = 1.0f;
    public Transform playerPosition;
    public float lenght = 10.0f;
    private Vector3 newPosition = new Vector3(1,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= newPosition * trackSpeed;
        float temp = this.transform.position.x;
        float temp2 = playerPosition.position.x - lenght;
        if (temp < temp2)
        {
            this.transform.position = new Vector3(playerPosition.position.x, -0.48f, 0);
            Debug.Log("Translate to position");
        }
            
    }
}
