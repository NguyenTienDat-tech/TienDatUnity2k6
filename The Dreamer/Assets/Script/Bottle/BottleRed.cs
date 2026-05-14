using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRed : Bottle
{
    protected override void General(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.AddHealth(value);
    }

   
}
