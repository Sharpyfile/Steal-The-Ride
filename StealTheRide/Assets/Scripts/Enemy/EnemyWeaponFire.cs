using UnityEngine;

public class EnemyWeaponFire : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bullet;

    private float range = 1.5f;
    private float timestampFiring;
    private Transform playerToFollow;

    void Start()
    {
        timestampFiring = Time.time;
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (timestampFiring <= Time.time && Vector2.Distance(transform.position, playerToFollow.position) < range)
        {
            Fire();
        }
    }

    void Fire()
    {
        timestampFiring = Time.time + fireCooldown;
        GameObject.Instantiate(bullet, transform.position, transform.rotation).SetActive(true);
    }
}
