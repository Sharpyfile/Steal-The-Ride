using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitSolidPSPrefab;
    public GameObject hitEnemyPSPrefab;
    public float speed;
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float spreadFactor;
    public float SpreadFactor
    {
        get { return spreadFactor; }
        set { spreadFactor = value; }
    }

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
            LaunchPS(hitEnemyPSPrefab);
            collision.gameObject.SendMessage("ApplyDamageEnemy", damage);
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
