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
    private Transform playerToFollow;
    private GameObject player;
    private bool isEnemyTriggered = false;

    void Start()
    {
        timestampFiring = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;
    }

    void Update()
    {
        isTriggered();
        
        if (timestampFiring <= Time.time && Vector2.Distance(transform.position, playerToFollow.position) < range && bulletsInMagazine > 0 && isEnemyTriggered == true)
        {
            Fire();
        }

        if(bulletsInMagazine == 0)
        {
            Invoke("Reload", magazineSize);
        }
    }

    void isTriggered()
    {
        var heading = playerToFollow.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        //Debug.Log(hit.collider.gameObject);
        //Debug.DrawRay(transform.position, direction);

        if (hit.collider != null && hit.collider.gameObject == player)
        {
            isEnemyTriggered = true;
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
}
