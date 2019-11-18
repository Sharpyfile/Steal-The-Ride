using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitSolidPSPrefab;
    public GameObject hitEnemyPSPrefab;
    public Rigidbody2D bullet;
    public Transform firePoint;

    public float speed;
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float damage;
    public float Damage
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

    public Vector2 Direction { get => direction; set => direction = value; }

    private Vector2 direction;

    private void Start()
    {
        //bullet = GetComponent<Rigidbody2D>();
        //bullet.velocity = new Vector2(speed, 0);
    }

    private void Awake()
    {
        //WeaponFire weapon = GameObject.FindObjectOfType<WeaponFire>();
        ////Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //Vector2 target = new Vector2(weapon.transform.position.x, weapon.transform.position.y);

        //if (RevolverFire.isSuperShot)
        //{
        //    target.x += Random.Range(-spreadFactor, spreadFactor);
        //    target.y += Random.Range(-spreadFactor, spreadFactor);
        //}

        //Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        //direction = target;// - bulletPosition;
        //direction.Normalize();
    }

    private void Update()
    {
        //vector2 position = transform.position;

        //position += direction * speed * time.deltatime;

        //transform.position = position;
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
            collision.gameObject.SendMessage("ApplyDamageEnemy", this);
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
