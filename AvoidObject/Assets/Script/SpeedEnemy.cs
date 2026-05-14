using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DaoChieu()
    {
        speed = -speed;

        Vector3 Dao = transform.localScale;
        Dao.x *= -1;
        transform.localScale = Dao;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            DaoChieu();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            PoolingManager.Despawn(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PoolingManager.Despawn(gameObject); 
        }
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
