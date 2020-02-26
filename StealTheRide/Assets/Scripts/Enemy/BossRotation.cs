using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    public float enemySpeed;
    public float nextWaypointDistance = 0.1f;

    public Animator animator;
    private GameObject player;
    private Transform playerToFollow;

    private Rigidbody2D rb;

    private float waitTime;
    private float startWaitTime;
    public Transform[] moveSpotsFirstPhase;
    public Transform TNTSpot;
    public Transform MachineGunSpot;
    public Transform EscapeSpot;
    private int startSpotFirstPhase;

    public EnemyWeaponFire enemyWeaponFire;
    public EnemyStatistics enemyStatistics;

    public bool firstPhase;
    public bool firstPhaseMove;
    public bool firstPhaseTNT;

    public bool secondPhase;
    public bool secondPhaseTNT;
    public bool secondPhaseMachineGun;

    private float startHealth;
    private float currentHealth;

    private float timestampNow;
    private float timestampAfter;
    private float timestampAfterFirstStage;
    private float phaseCooldown;

    public bool isFirstPhaseActive;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;
        animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();

        waitTime = startWaitTime;

        startSpotFirstPhase = 0;
        //firstPhase = true;
        firstPhaseMove = true;
        firstPhaseTNT = false;

        //secondPhase = false;
        secondPhaseTNT = false;
        secondPhaseMachineGun = true;

        startHealth = enemyStatistics.enemyHealth;
        currentHealth = startHealth;

        timestampNow = 0.0f;
        timestampAfter = 0.0f;
        timestampAfterFirstStage = 0.0f;
        phaseCooldown = 10.0f;
}

// Update is called once per frame
void Update()
    {
        if (PauseMenu.IsPaused)
            return;

        currentHealth = enemyStatistics.enemyHealth;
        Debug.Log("Health: " + currentHealth);

        if(currentHealth/startHealth >= 0.5)
        {
            //firstPhase = true;
            //secondPhase = false;
        }
        
        if (currentHealth / startHealth < 0.5 && firstPhase == true)
        {
            //firstPhase = false;
            //secondPhase = true;

            Escape();
        }

        //pierwsza faza -> szczelanie i dynamit
        if (firstPhase == true && secondPhase == false && isFirstPhaseActive == true)
        {
            timestampNow = Time.time;

            if (timestampAfter == 0.0f)
            {
                timestampAfter = timestampNow + phaseCooldown;
            }
            
            if (timestampAfter <= timestampNow && firstPhaseMove == true)
            {
                firstPhaseMove = false;
                firstPhaseTNT = true;
                timestampAfter = 0.0f;
            }
            else if (timestampAfter <= timestampNow && firstPhaseMove == false)
            {
                firstPhaseMove = true;
                firstPhaseTNT = false;
                timestampAfter = 0.0f;
            }

            if (firstPhaseMove == true && firstPhaseTNT == false)
            {
                MoveUpAndDownFirstPhase();
            }

            if (firstPhaseMove == false && firstPhaseTNT == true)
            {
                MoveTowardsTNT();
            }
        }

        //druga faza -> karabin i dynamit
        if (firstPhase == false && secondPhase == true && isFirstPhaseActive == false)
        {
            firstPhaseMove = false;
            firstPhaseTNT = false;

            timestampNow = Time.time;

            if (timestampAfter == 0.0f)
            {
                timestampAfter = timestampNow + phaseCooldown;
            }

            if (timestampAfter <= timestampNow && secondPhaseMachineGun == true)
            {
                secondPhaseMachineGun = false;
                secondPhaseTNT = true;
                timestampAfter = 0.0f;
            }
            else if (timestampAfter <= timestampNow && firstPhaseMove == false)
            {
                secondPhaseMachineGun = true;
                secondPhaseTNT = false;
                timestampAfter = 0.0f;
            }

            if (secondPhaseMachineGun == true && secondPhaseTNT == false)
            {
                MoveTowardsMachineGun();
            }

            if (secondPhaseMachineGun == false && secondPhaseTNT == true)
            {
                MoveTowardsTNT();
            }

        }
    }

    void MoveUpAndDownFirstPhase()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpotsFirstPhase[startSpotFirstPhase].position, enemySpeed / 5000.0f);

        if (Vector2.Distance(transform.position, moveSpotsFirstPhase[startSpotFirstPhase].position) < 0.2f)
        {
            if (waitTime <= 0.0f)
            {
                startSpotFirstPhase += 1;
                waitTime = startWaitTime;

                if (startSpotFirstPhase > 1)
                {
                    startSpotFirstPhase = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void MoveTowardsTNT()
    {
        transform.position = Vector2.MoveTowards(transform.position, TNTSpot.position, enemySpeed / 5000.0f);
    }

    void MoveTowardsMachineGun()
    {
        transform.position = Vector2.MoveTowards(transform.position, MachineGunSpot.position, enemySpeed / 5000.0f);
    }

    void Escape()
    {
        transform.position = Vector2.MoveTowards(transform.position, EscapeSpot.position, enemySpeed / 4000.0f);

        timestampNow = Time.time;
        if (timestampAfterFirstStage == 0.0f)
        {
            timestampAfterFirstStage = timestampNow + 1.0f;
        }

        if (Vector2.Distance(transform.position, EscapeSpot.position) < 0.1f && timestampAfterFirstStage <= timestampNow)
        {
            Destroy(this.gameObject);
        }
    }
}
