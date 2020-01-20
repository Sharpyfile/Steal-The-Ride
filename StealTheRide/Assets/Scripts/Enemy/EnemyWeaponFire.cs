using UnityEngine;

public class EnemyWeaponFire : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bullet;
    public ParticleSystem particleSystem;
    public int fireParticleCount = 10;
    public float speed = 2f;
    public int magazineSize = 6;
    public int bulletsInMagazine = 6;

    private float range = 1.5f;
    private float timestampFiring;
    private GameObject player;
    private Transform playerToFollow;
    private bool enemyShoot;

    void Start()
    {
        timestampFiring = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;
        enemyShoot = false;
    }

    void Update()
    {
        CheckBeforeShoot();

        if (timestampFiring <= Time.time && Vector2.Distance(transform.position, playerToFollow.position) < 1.5f*range && bulletsInMagazine > 0 && enemyShoot == true)
        {
            Fire();
        }

        if (bulletsInMagazine == 0)
        {
            Invoke("Reload", magazineSize);
        }
    }

    void Fire()
    {
        timestampFiring = Time.time + fireCooldown;
        particleSystem.Emit(fireParticleCount);
        //GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);

        GameObject newBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
        newBullet.SetActive(true);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);

        bulletsInMagazine--;
    }

    void Reload()
    {
        bulletsInMagazine = magazineSize;
    }

    void CheckBeforeShoot()
    {
        var heading = playerToFollow.position - transform.position;
        //var heading = transform.position - playerToFollow.position;
        var distance = heading.magnitude * 0.5f;
        var direction = (heading / distance);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        //Debug.Log(hit.collider.gameObject);
        Debug.DrawRay(transform.position, direction);

        if (hit.collider != null && hit.collider.gameObject == player)
        {
            enemyShoot = true;
        }
    }
}
