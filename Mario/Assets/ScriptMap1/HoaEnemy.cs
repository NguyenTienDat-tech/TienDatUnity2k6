using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaEnemy : MonoBehaviour
{
    private SpriteRenderer hinhanh;
    private BoxCollider2D box;
    public TextCoin text;
    public ManagerGame game;


    private void Start()
    {
        hinhanh = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.CompareTag("Figure"))
        {
            hinhanh.enabled = false;
            box.enabled = false;
            Destroy(collision.gameObject);
            text.ChuCoin();
        }
    }

    private void Update()
    {
        if (transform.position.x < -15f)
        {
            hinhanh.enabled = true;
            box.enabled = true;
        }
        if (text.coin == 50)
        {
            game.NextLever();
        }
    }

}
