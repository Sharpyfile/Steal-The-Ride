using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStatistics : ALootable
{
    public float enemyHealth;
    public GameObject enemy;
    public GameObject bleedPSPrefab;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        Debug.Log("You hit the enemy!");
        if (enemyHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                AudioManager.instance.Play("Death");
                Debug.Log("You killed the enemy!");
            }
            Drop();
            Destroy(enemy);
            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            if (gameObject.tag == "Enemy")
            {
                AudioManager.instance.Play("Pain");
            }
        }
            
    }

}
