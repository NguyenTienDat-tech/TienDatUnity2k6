using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockAn : MonoBehaviour
{
    public GameObject QuaiNam;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            BlockSecret block = collision.gameObject.GetComponent<BlockSecret>();
            if ((collision.contacts[0].normal.y > 0.5f))
            {
                QuaiNam.SetActive(true);
            }
                
        }
    }

}
