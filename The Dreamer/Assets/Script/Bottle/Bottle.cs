using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bottle : MonoBehaviour
{
    [SerializeField] protected int value = 5;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            General(collision.gameObject);
            PoolingManager.Despawn(gameObject);
        }
    }

    protected abstract void General(GameObject player);


}


