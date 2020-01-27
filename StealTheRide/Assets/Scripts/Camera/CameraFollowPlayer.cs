using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector3 offset;
    
    void Update()
    {
        offset.x = player.position.x;
        offset.y = this.transform.position.y;
        offset.z = -10;
        this.transform.position = offset;
    }
}
