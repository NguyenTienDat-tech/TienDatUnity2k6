using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMap2 : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public ManagerGame game;
    public Transform ViTri;
    public BanDan Figure;

    private float thoigiancho;
    private float tocdoban = 0.5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void DiChuyen()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * speed;
        }
        if ( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * speed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * speed;
        }



        if ( Input.GetKeyDown(KeyCode.F) && Time.time > thoigiancho)
        {
            thoigiancho = Time.time + tocdoban;
            Instantiate(Figure, ViTri.position, Quaternion.identity);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            game.ResetLever();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.ResetLever();
        }
        
    }

    private void Update()
    {
        DiChuyen();
    }


}
