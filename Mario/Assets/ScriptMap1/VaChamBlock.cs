using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaChamBlock : MonoBehaviour
{
    public ManagerGame managerGame;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (collision.gameObject.CompareTag("PhaBlock"))
        {
            if (collision.contacts[0].normal.y < 0f)
            {
                Destroy(collision.gameObject);

                
            }
        }
        if (collision.gameObject.CompareTag("Flag"))
        {
            managerGame.NextLever();
        }
    }
}
