using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    public Rigidbody2D player;
    public SpriteRenderer playerSprite;
    public GameObject bleedPSPrefab;
    public GameObject firePoint;
    public float walkingSpeed = 2f;
    public float sprintingSpeed = 5f;
    public int maxHealth = 10;
    public int health = 10;

    public UnityEvent playerDamaged;

    private Vector3 mousePosition;
    private Vector2 playerInput;
    private float speed;

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

    void ApplyDamagePlayer(EnemyBullet bullet)
    {
        float psAngle = Mathf.Atan2(bullet.Direction.y, bullet.Direction.x) * Mathf.Rad2Deg;
        GameObject psObject = Instantiate(bleedPSPrefab, transform.position, bleedPSPrefab.transform.rotation * Quaternion.AngleAxis(psAngle, Vector3.forward));
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        Destroy(psObject, ps.main.duration);

        health -= bullet.damage;
        playerDamaged.Invoke();
        Debug.Log("You have been hit");
        if (health <= 0)
        {
            AudioManager.instance.Play("Death");
            Debug.Log("You are dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            AudioManager.instance.Play("Pain");
        }
    }
}
