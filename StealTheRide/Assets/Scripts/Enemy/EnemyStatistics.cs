using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStatistics : MonoBehaviour
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
        float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
            AudioManager.instance.Play("Death");
            Debug.Log("You killed the enemy!");
            Destroy(enemy);
            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            AudioManager.instance.Play("Pain");
        }
            
    }

}
