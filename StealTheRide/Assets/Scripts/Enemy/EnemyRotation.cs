using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour 
{
    public float range;
	public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;

    public Animator animator;
    private Transform playerToFollow;

    void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerToFollow.position) < range)
		{
			if (Vector2.Distance(transform.position, playerToFollow.position) > stoppingDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, enemySpeed);
                animator.SetBool("Movement", true);
			}
			else if (Vector2.Distance(transform.position, playerToFollow.position) < stoppingDistance && Vector2.Distance(transform.position, playerToFollow.position) > retreatDistance)
			{
				transform.position = this.transform.position;
                animator.SetBool("Movement", false);
            }  
			else if (Vector2.Distance(transform.position, playerToFollow.position) < retreatDistance)
			{
				transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, -enemySpeed);
                animator.SetBool("Movement", true);
            } 
		}
        else if (Vector2.Distance(transform.position, playerToFollow.position) >= range)
		{
			transform.position = this.transform.position;
            animator.SetBool("Movement", false);
        }
        animator.SetInteger("Section", CalculateSection());
    }

    private float GetRotationAngle()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        currentPosition.x = playerToFollow.position.x - currentPosition.x;
        currentPosition.y = playerToFollow.position.y - currentPosition.y;


        return Mathf.Atan2(currentPosition.y, currentPosition.x) * Mathf.Rad2Deg;
    }

    private int CalculateSection()
    {
        float angle = GetRotationAngle();
        angle = GetRotationAngle();
        if (angle < 0)
            angle = 360 + angle;
        int section = 0; ;
        if (angle >= 330 || angle < 30)
            section = 0;
        else if (angle >= 30 && angle < 90)
            section = 1;
        else if (angle >= 90 && angle < 150)
            section = 2;
        else if (angle >= 150 && angle < 210)
            section = 3;
        else if (angle >= 210 && angle < 270)
            section = 4;
        else if (angle >= 270 && angle < 330)
            section = 5;

        return section;
    }
}
