using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mario : MonoBehaviour
{
    public float speed = 7f;
    public LayerMask Layer;
    public Transform ViTri;
    public bool KiemTra;
    private Rigidbody2D rb;
    public Camera cameraMain;
    public float dichuyen;
    public ManagerGame managerGame;


    public float LucNhayMax = 30f;
    public float ThoiGianCho = 0.5f;

    public bool DaChet = false;

    public HealMario heal;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        SpeedMario();
        NhayMario();
    }

    private void SpeedMario()
    {
        dichuyen = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dichuyen * speed, rb.velocity.y);

        if (dichuyen < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dichuyen > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


    private void NhayMario()
    {
        if (Input.GetKeyDown(KeyCode.Space) && KiemTra == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, LucNhayMax);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * ThoiGianCho);
        }
            KiemTra = Physics2D.OverlapCircle(ViTri.position, 0.2f, Layer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")  && !DaChet)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (collision.contacts[0].normal.y > 0.5f)
            {
                if (enemy != null)
                {
                    enemy.BiTieuDiet();
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (!DaChet)
                {
                    heal.live();

                    if (DaChet == true)
                    {
                        rb.velocity = Vector2.zero;
                        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                        GetComponent<Collider2D>().enabled = false;

                    }
                }
            }
        }
        if (collision.gameObject.CompareTag("Cappa") && !DaChet)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (collision.contacts[0].normal.y > 0.5)
            {
                if (enemy != null)
                {
                    enemy.maicoppa();
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (!DaChet && enemy.DaBienThanhMai == false)
                {
                    heal.live();

                    if (DaChet == true)
                    {
                        rb.velocity = Vector2.zero;
                        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                        GetComponent<Collider2D>().enabled = false;

                    }
                }
            }
        }     
    }


    private void FixedUpdate()
    {
        Vector3 Vitri = transform.position;
        Vector3 left = cameraMain.ScreenToWorldPoint(Vector2.zero);
        Vector3 right = cameraMain.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vitri.x = Mathf.Clamp(Vitri.x, left.x + 0.5f, right.x - 0.5f);
        transform.position = Vitri;

        if (transform.position.y < -10)
        {
            managerGame.ResetLever();
        }
    }
}
