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
    public float duckRadius = 0.25f;

    public UnityEvent playerDamaged;

    private Vector3 mousePosition;
    private Vector2 playerInput;
    private float speed;
    private bool ducked = false;

    private int defaultLayer;
    private int obstaclesLayer;

    public bool GetDucked()
    {
        return ducked;
    }

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        defaultLayer = gameObject.layer;
        obstaclesLayer = LayerMask.NameToLayer("Obstacles");
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
            gameObject.layer = defaultLayer;
        } else if (!ducked && on)
        {
            ducked = true;
            playerSprite.color = new Color(0, 255, 0);
            player.constraints = RigidbodyConstraints2D.FreezePosition;
            if (GetClosestObstacle(GetObstacles()) <= duckRadius)
            {
                gameObject.layer = obstaclesLayer;
            }
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

    private Transform[] GetObstacles()
    {
        GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<Transform> obstacleList = new List<Transform>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].layer == obstaclesLayer)
            {
                obstacleList.Add(objects[i].transform);
            }
        }
        return obstacleList.ToArray();
    }

    private float GetClosestObstacle(Transform[] obstacles)
    {
        float minDist = Mathf.Infinity;
        Vector2 currentPos = transform.position;
        foreach (Transform t in obstacles)
        {
            float dist = Vector2.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                minDist = dist;
            }
        }
        return minDist;
    }
}
