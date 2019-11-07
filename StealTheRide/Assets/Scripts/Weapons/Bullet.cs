using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float speed = 2f;
    public int damage;
    public float spreadFactor = 0.3f;
    private Vector2 direction;
    public Rigidbody2D bullet;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (RevolverFire.isSuperShot)
        {
            target.x += Random.Range(-spreadFactor, spreadFactor);
            target.y += Random.Range(-spreadFactor, spreadFactor);
        }

        Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        direction = target - bulletPosition;
        direction.Normalize();
    }

    private void Update()
    {
        Vector2 position = transform.position;

        position += direction * speed * Time.deltaTime;

        transform.position = position;
    }

    //private void FixedUpdate()
    //{
    //    bullet.AddForce(direction * speed, ForceMode2D.Impulse);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamageEnemy", damage);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);

    }

    public void SetSpeed(float newSpeed)
    {
        speed = 5;
    }

}
