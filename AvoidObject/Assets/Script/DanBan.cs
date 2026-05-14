using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanBan : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke("TuHuy", 2f);
    }

    private void TuHuy()
    {
        PoolingManager.Despawn(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PoolingManager.Despawn(collision.gameObject);
            PoolingManager.Despawn(gameObject);
        }       
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolingManager.Despawn(gameObject);
        }
    }
}
