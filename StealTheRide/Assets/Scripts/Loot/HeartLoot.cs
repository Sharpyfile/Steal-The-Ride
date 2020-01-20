using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLoot : MonoBehaviour
{
    public int minHealth = 1;
    public int maxHealth = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<PlayerStatistics>().health += Random.Range(minHealth, maxHealth);
            
            AudioManager.instance.Play("PickupAmmo");
            Destroy(gameObject);
        }
    }
}
