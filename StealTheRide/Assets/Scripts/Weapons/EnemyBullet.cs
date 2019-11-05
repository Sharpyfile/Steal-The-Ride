using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage;

    public Rigidbody2D bullet;
    public Transform player;

    private Vector2 direction;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Awake()
    {
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y);
        Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        direction = playerPosition - bulletPosition;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        bullet.AddForce(direction * speed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyDamagePlayer", damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);

    }
}
