using UnityEngine;

public class EnemyWeaponFire : MonoBehaviour
{
    public float fireCooldown = 2f;
    public GameObject bullet;

    private float timestampFiring;

    void Start()
    {
        timestampFiring = Time.time;
    }

    void Update()
    {
        if (timestampFiring <= Time.time)
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
