using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSecret : MonoBehaviour
{
    public GameObject game;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if ((collision.contacts[0].normal.y > 0.5f))
            {
                game.SetActive(true);
            }
           
        }
    }
}
