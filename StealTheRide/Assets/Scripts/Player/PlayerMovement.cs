using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    private float speed;
    private Vector2 playerInput;
    public float walkingSpeed = 2f;
    public float sprintingSpeed = 5f;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        speed = Input.GetKey(KeyCode.LeftShift) ? sprintingSpeed : walkingSpeed;
        player.velocity = playerInput * speed;
    }
}
