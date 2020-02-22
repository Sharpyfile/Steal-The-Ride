using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelController : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 destination;
    public float yCoordinate;
    public float speed;
    private float timeElapsed = 0.0f;
    public GameObject enemies;

    void Start()
    {
        startPosition = this.transform.position;
        destination = startPosition;
        destination.y += yCoordinate;

    }
    void Update()
    {
        if (timeElapsed <= 1.0f && enemies.transform.childCount == 0)
        {
            transform.position = Vector3.Lerp(startPosition, destination, timeElapsed);
            timeElapsed += speed;
        }
            
    }
   
}
