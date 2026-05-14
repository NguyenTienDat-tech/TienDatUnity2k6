using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanDan : MonoBehaviour
{
    public float Speed = 10f;
    public ManagerGame game;


    private void Start()
    {
        Destroy(gameObject, 3f);
    }


    public void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("ThanhChan"))
        {
            Destroy(gameObject);
        }
    }
}
