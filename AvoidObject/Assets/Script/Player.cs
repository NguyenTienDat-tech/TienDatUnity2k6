using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public TimPlayer tim;
    public Variables variables;

    public DanBan Figure;
    public Transform ViTriDan;

    public float tocdoban = 0.5f;
    private float thoigiancho = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            tim.healTim();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            tim.healTim();
        }
    }


    private void DiChuyen()
    {
        float dir = 0f;

        
        if (variables != null)
        {
            
            if (variables.declarations.IsDefined("moveHorizontal")) // Kiểm tra "moveHorizontal" có tồn tại không
            {
                object val = variables.declarations.Get("moveHorizontal");
                if (val != null)
                {
                    dir = System.Convert.ToSingle(val);
                }
            }
        }

        rb.velocity = new Vector2(dir * Speed, rb.velocity.y);

        if (dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }






        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * Speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * Speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
       


        if (Input.GetButtonDown("Fire1") && Time.time > thoigiancho)
        {
            thoigiancho = Time.time + tocdoban;

            Quaternion Q = Quaternion.identity;

            if (transform.localScale.x < 0)
            {
                Q = Quaternion.Euler(0, 180, 0);
            }


            PoolingManager.Spawn(Figure, ViTriDan.position, Q);
        }



    }

    private void Animation()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            animator.SetBool("KiemTraChay", true);
        }
        else
        {
            animator.SetBool("KiemTraChay", false);
        }
    }

    public void AnimationDeath()
    {
        animator.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }

    void Update()
    {
        DiChuyen();
        Animation();
    }
}
