using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.3f, 0.6f);
        GetComponent<Animator>().Play(0, -1, Random.value);
    }
}
