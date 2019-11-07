using UnityEngine;

public class EnemyWeaponFire : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bullet;

    private float range = 1.5f;
    private int magazineSize = 6;
    private int bulletsInMagazine = 6;
    private float timestampFiring;
    private Transform playerToFollow;

    void Start()
    {
        timestampFiring = Time.time;
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (timestampFiring <= Time.time && Vector2.Distance(transform.position, playerToFollow.position) < range && bulletsInMagazine > 0)
        {
            Fire();
        }

        if(bulletsInMagazine == 0)
        {
            Invoke("Reload", 6);
        }
    }

    void Fire()
    {
        timestampFiring = Time.time + fireCooldown;
        GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);
        bulletsInMagazine--;
    }

    void Reload()
    {
        bulletsInMagazine = 6;
    }
}
