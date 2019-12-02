using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
    public float lifetime;
    public GameObject destroyEffect;

   

    private void Start()
    {
        transform.Rotate(0, 180, 0);
        Invoke("DestroyArrow", lifetime);
    }


    void DestroyArrow()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   
}
