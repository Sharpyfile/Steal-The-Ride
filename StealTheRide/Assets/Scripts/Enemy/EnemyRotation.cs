using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRotation : MonoBehaviour
{
    public bool enemyTriggered;

    public float range;
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public float nextWaypointDistance = 0.3f;

    public bool EnemyTriggered
    {
        get { return enemyTriggered; }
        set { enemyTriggered = value; }
    }

    private Transform playerToFollow;
    private GameObject player;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector2 force;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;

        enemyTriggered = false;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rb.position, playerToFollow.position, OnPathComplete);

        force = new Vector2(0.0f, 0.0f);
    }

    void Update()
    {
        CheckIfEnemySeePlayer();

        if (enemyTriggered == true)
        {
            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            rb.AddForce(EnemyAfterPlayer(direction, force));

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, playerToFollow.position, OnPathComplete);
    }

    Vector2 EnemyAfterPlayer(Vector2 direction, Vector2 force)
    {
        if (Vector2.Distance(transform.position, playerToFollow.position) < range)
        {
            if (Vector2.Distance(transform.position, playerToFollow.position) > stoppingDistance)
            {
                force = direction * enemySpeed;
                //transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, enemySpeed);
            }
            else if (Vector2.Distance(transform.position, playerToFollow.position) < stoppingDistance && Vector2.Distance(transform.position, playerToFollow.position) > retreatDistance)
            {
                force = direction * 0;
                //transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, playerToFollow.position) < retreatDistance)
            {
                force = direction * -enemySpeed;
                //transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, -enemySpeed);
            }
        }
        else if (Vector2.Distance(transform.position, playerToFollow.position) >= range)
        {
            force = direction * 0;
            //transform.position = this.transform.position;
        }
        return force;
    }

    void CheckIfEnemySeePlayer()
    {
        var heading = playerToFollow.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        //Debug.Log(hit.collider.gameObject);
        //Debug.DrawRay(transform.position, direction);

        if (hit.collider != null && hit.collider.gameObject == player)
        {
            enemyTriggered = true;
        }
    }
}

