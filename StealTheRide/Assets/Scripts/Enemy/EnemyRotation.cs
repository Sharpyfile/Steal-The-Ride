using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour 
{
    public float range;
	public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform playerToFollow;

    void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerToFollow.position) < range)
		{
			if (Vector2.Distance(transform.position, playerToFollow.position) > stoppingDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, enemySpeed);
			}
			else if (Vector2.Distance(transform.position, playerToFollow.position) < stoppingDistance && Vector2.Distance(transform.position, playerToFollow.position) > retreatDistance)
			{
				transform.position = this.transform.position;
			}  
			else if (Vector2.Distance(transform.position, playerToFollow.position) < retreatDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, -enemySpeed);
			} 
		} else if (Vector2.Distance(transform.position, playerToFollow.position) >= range)
		{
			transform.position = this.transform.position;
		}	  
    }
}
