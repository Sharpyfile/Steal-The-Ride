using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistics : ALootable
{
    public float enemyHealth;
    public GameObject enemy;
    public GameObject bleedPSPrefab;

    public Transform player;

    public GameObject healthBarGO;
    public HealthBar healthBar;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (gameObject.tag == "Boss")
        {
            healthBarGO = GameObject.Find("HealthBar");
            healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
            healthBar.SetMaxHealth(enemyHealth);
            healthBar.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

    }

    void Update()
    {

    }

    void ApplyDamageEnemy(Bullet bullet)
    {
        float psAngle = Mathf.Atan2(bullet.Direction.y, bullet.Direction.x) * Mathf.Rad2Deg;
        GameObject psObject = Instantiate(bleedPSPrefab, transform.position, bleedPSPrefab.transform.rotation * Quaternion.AngleAxis(psAngle, Vector3.forward));
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        Destroy(psObject, ps.main.duration);

        enemyHealth -= bullet.damage;

        if (gameObject.tag == "Boss")
        {
            healthBar.gameObject.transform.localScale = new Vector3(1, 1, 1);
            healthBar.setHealth(enemyHealth);
        }
        Debug.Log("You hit the enemy!");
        if (enemyHealth <= 0)
        {
            if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
            {
                AudioManager.instance.Play("Death");
                Debug.Log("You killed the enemy!");
            }
            Drop();
            Destroy(enemy);
            if (gameObject.tag == "Boss")
            {
                healthBar.gameObject.SetActive(false);
            }
        }
        else
        {
            if (gameObject.tag == "Enemy" || gameObject.tag == "Boss")
            {
                AudioManager.instance.Play("Pain");
            }
        }
            
    }

}
