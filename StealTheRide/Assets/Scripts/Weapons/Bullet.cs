using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage;
    public float spreadFactor = 0.3f;
    private Vector2 direction;
    public Rigidbody2D bullet;
    public GameObject thisBullet;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (WeaponFire.isSuperShot)
        {
            target.x += Random.Range(-spreadFactor, spreadFactor);
            target.y += Random.Range(-spreadFactor, spreadFactor);
        }

        Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        direction = target - bulletPosition;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        bullet.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamageEnemy", damage);
            Destroy(thisBullet);

        }
        if (collision.gameObject.tag == "Wall")
            Destroy(thisBullet);

    }

}
