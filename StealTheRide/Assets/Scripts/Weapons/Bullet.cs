using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2f;
    public int damage = 10;
    private Vector2 direction;
    public Rigidbody2D bullet;

    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        direction = target - bulletPosition;
        direction.Normalize();
        
    }

    private void FixedUpdate()
    {
        bullet.AddForce(direction * speed, ForceMode2D.Force);
    }

}
