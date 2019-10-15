using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    public Rigidbody2D player;
    private float speed;
    private Vector2 playerInput;
    public float walkingSpeed = 2f;
    public float sprintingSpeed = 5f;
    private Vector3 mousePosition;
    public int playerHealth = 10;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    void PlayerMove()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        speed = Input.GetKey(KeyCode.LeftShift) ? sprintingSpeed : walkingSpeed;
        player.velocity = playerInput * speed;
    }

    void PlayerRotate()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ApplyDamagePlayer(int damage)
    {
        playerHealth -= damage;
        Debug.Log("You have been hit");
        if (playerHealth <= 0)
        {
            Debug.Log("You are dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }
}
