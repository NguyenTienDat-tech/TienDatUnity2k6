using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 2f;
    private Vector2 dichuyen = Vector2.left;
    private float timeCho = 0.2f;
    private Animator animator;
    public bool DaBienThanhMai;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rb.WakeUp();
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Speed = -Speed;


            Vector2 Dao = transform.localScale;
            Dao.x *= -1;
            transform.localScale = Dao;
        }
        if (collision.gameObject.CompareTag("Cappa"))
        {
            Enemy scriptCuaRua = collision.gameObject.GetComponent<Enemy>();
            if (scriptCuaRua.DaBienThanhMai == true)
            {
                BiTieuDiet();
                maicoppa();
            }
        }
    }

    public void BiTieuDiet()
    {
        rb.GetComponent<Collider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;



        enabled = false;
        animator.SetBool("DeathEnemy", true);
        Destroy(gameObject, 0.2f);
    }

    public void maicoppa()
    {
        DaBienThanhMai = true;
        animator.SetBool("MaiCoppa", true);
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(15f, rb.velocity.y));
    }





    private void FixedUpdate()
    {
        if (DaBienThanhMai == false)
        {
            rb.velocity = new Vector2(dichuyen.x * Speed, rb.velocity.y);
        }     
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }


}
