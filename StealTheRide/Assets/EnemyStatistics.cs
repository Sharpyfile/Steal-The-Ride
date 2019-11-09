using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStatistics : MonoBehaviour
{
    public int enemyHealth;
    public GameObject enemy;

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

    void ApplyDamageEnemy(int damage)
    {
        enemyHealth -= damage;
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
