using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        offset = player.position;
        offset.z = -10;
        this.transform.position = offset;

    }
}
