using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : ManagerDamage
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerEnermy enermy = collision.gameObject.GetComponent<PlayerEnermy>();
        if (collision.gameObject.CompareTag("Player"))
        {
            enermy.AddEnermy(1);
            PoolingManager.Despawn(gameObject);
        }
    }
}
