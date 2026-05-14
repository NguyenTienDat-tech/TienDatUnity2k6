using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : ManagerPickGun
{
    [SerializeField] DataWeapon currentWeapon;


    protected override void Gun()
    {
        PlayerControlWeapon playerWeapon = player.GetComponent<PlayerControlWeapon>();
        playerWeapon.PickWeapon(currentWeapon);
        PoolingManager.Despawn(gameObject);
    }

}
