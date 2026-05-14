using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 18f;
    public int damage;

    private void OnEnable()
    {
        Invoke("Buttle", 1);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Buttle()
    {
        PoolingManager.Despawn(gameObject);
    }

    public void Setup(float newSpeed, int newDamage)
    {
        this.speed = newSpeed;
        this.damage = newDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolingManager.Despawn(gameObject);
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            HealthBox box = collision.gameObject.GetComponent<HealthBox>();
            box.TakeDamage(damage);
            PoolingManager.Despawn(gameObject);
        }
    }

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
}
