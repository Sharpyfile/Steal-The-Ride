using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    public Rigidbody2D player;
    public SpriteRenderer playerSprite;
    private float speed;
    private Vector2 playerInput;
    public float walkingSpeed = 2f;
    public float sprintingSpeed = 5f;
    private Vector3 mousePosition;
    public int playerHealth = 10;

    private bool ducked = false;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        PlayerDuck(Input.GetKey(KeyCode.LeftControl));
        PlayerMove();
        PlayerRotate();
    }

    void PlayerDuck(bool on)
    {
        if (ducked && !on)
        {
            ducked = false;
            playerSprite.color = new Color(255, 0, 0);
            player.constraints = RigidbodyConstraints2D.None;
        } else if (!ducked && on)
        {
            ducked = true;
            playerSprite.color = new Color(0, 255, 0);
            player.constraints = RigidbodyConstraints2D.FreezePosition;
        }
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
