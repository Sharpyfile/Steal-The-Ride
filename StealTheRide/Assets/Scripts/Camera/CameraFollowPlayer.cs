using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector3 offset;
    
    void Update()
    {
        offset = player.position;
        offset.z = -10;
        this.transform.position = offset;
    }
}
