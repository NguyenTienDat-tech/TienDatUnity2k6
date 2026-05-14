using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBlue : Bottle
{
    protected override void General(GameObject player)
    {
        PlayerEnermy playerEnermy = player.GetComponent<PlayerEnermy>();
        playerEnermy.AddEnermy(value);
    }

}
