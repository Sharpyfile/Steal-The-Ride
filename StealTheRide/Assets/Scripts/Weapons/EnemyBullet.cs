using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage;
    public Rigidbody2D bullet;
    public GameObject hitSolidPSPrefab;
    public GameObject hitEnemyPSPrefab;

    private Transform player;
    private Vector2 direction;

    bool isReady;

    public Vector2 Direction { get => direction; set => direction = value; }

    private void Start()
    {
        transform.Rotate(0, 180, 0);
        //    bullet = GetComponent<Rigidbody2D>();
        //    player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //private void Awake()
    //{
    //    player = GameObject.FindWithTag("Player").transform;
    //    Vector2 playerPosition = new Vector2(player.position.x, player.position.y);
    //    Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
    //    direction = playerPosition - bulletPosition;
    //    direction.Normalize();
    //}

    //private void Update()
    //{
    //    Vector2 position = transform.position;

    //    position += direction * speed * Time.deltaTime;

    //    transform.position = position;
    //}

    //private void FixedUpdate()
    //{
    //    bullet.AddForce(direction * speed, ForceMode2D.Force);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LaunchPS(hitEnemyPSPrefab);
            collision.gameObject.SendMessage("ApplyDamagePlayer", this);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            LaunchPS(hitSolidPSPrefab);
            Destroy(gameObject);
        }

    }

    private void LaunchPS(GameObject psPrefab)
    {
        GameObject psObject = Instantiate(psPrefab, transform.position, transform.rotation);
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        Destroy(psObject, ps.main.duration);
    }
}
