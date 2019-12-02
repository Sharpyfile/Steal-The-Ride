using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponRotate : MonoBehaviour
{
    private Transform playerToFollow;

    void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(playerToFollow.position.y - transform.position.y, playerToFollow.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
