using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMario : MonoBehaviour
{
    public GameObject Small;
    public GameObject Big;
    public ManagerGame game;
    public TextCoin textCoin;
    public Mario mario;

    public Vector3 ViTriNho;
    public Vector3 ViTriLon;


    void Start()
    {
        Small.SetActive(true);
        Big.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NamPhongDai"))
        {
            Big.SetActive(true);
            Small.SetActive(false);
            Destroy(collision.gameObject);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CapsuleCollider2D>().enabled = false;


            if(ViTriLon != null)
            {
                mario.ViTri.localPosition = ViTriLon;
            }


        }
        else if (collision.gameObject.CompareTag("NamThuNho"))
        { 
            Big.SetActive(false);
            Small.SetActive(true);
            Destroy(collision.gameObject);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = true;


            if (ViTriNho != null)
            {
                mario.ViTri.localPosition = ViTriNho;
            }

        }
        else if (collision.gameObject.CompareTag("SaoMayMan"))
        {
            game.ResetLever();
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            textCoin.ChuCoin();
            Destroy(collision.gameObject);
        }
    }



    void Update()
    {
        
    }
}
