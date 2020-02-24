﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    public float range;
    public float enemySpeed;
    public bool enemyTriggered;
    public float nextWaypointDistance = 0.1f;

    public Animator animator;
    private GameObject player;
    private Transform playerToFollow;

    public bool EnemyTriggered
    {
        get { return enemyTriggered; }
        set { enemyTriggered = value; }
    }

    private Rigidbody2D rb;
    private Vector2 force;
    private Vector2 forceZero;
    private bool enemyInRange;

    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpotsFirstPhase;
    public Transform TNTSpot;
    public Transform MachineGunSpot;
    private int startSpotFirstPhase;

    private float startWaitTimeDuringCombat;
    private float waitTimeDuringCombat;

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

    public int firstPhaseMoveUpAndDownCounter;

    private float timestampMoving;
    private float moveCooldown;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerToFollow = player.transform;
        animator = GetComponentInChildren<Animator>();

        enemyInRange = false;
        enemyTriggered = false;
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(0.0f, 0.0f);
        forceZero = new Vector2(0.0f, 0.0f);

        waitTime = startWaitTime;

        startWaitTimeDuringCombat = 0.5f;
        waitTimeDuringCombat = startWaitTimeDuringCombat;
        startSpotFirstPhase = 0;
        firstPhase = true;
        firstPhaseMove = true;
        firstPhaseTNT = false;

        secondPhase = false;
        secondPhaseTNT = false;
        secondPhaseMachineGun = false;

        //startHealth = enemyStatistics.enemyHealth;
        //currentHealth = startHealth;

        timestampMoving = Time.time;
        moveCooldown = 2.0f;

}

// Update is called once per frame
void Update()
    {
        if (PauseMenu.IsPaused)
            return;

        //currentHealth = enemyStatistics.enemyHealth;

        if(true) //if (currentHealth/startHealth >= 0.5)
        {
            firstPhase = true;
            secondPhase = false;
        }

        if(false) //if (currentHealth / startHealth < 0.5)
        {
            firstPhase = false;
            secondPhase = true;
        }

        //pierwsza faza -> szczelanie i dynamit
        if (firstPhase == true && secondPhase == false)
        {
            MoveUpAndDownFirstPhase();
            MoveTowardsTNT();
        }

        //druga faza -> karabin i dynamit
        if (firstPhase == false && secondPhase == true)
        {
            firstPhaseMove = false;
            firstPhaseTNT = false;
            
        }
    }

    void MoveUpAndDownFirstPhase()
    {
        timestampMoving = Time.time + moveCooldown;

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

}