using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlWeapon : MonoBehaviour
{
    [SerializeField] SpriteRenderer handWeapon;

    public DataWeapon currentWeapon;

    public void PickWeapon(DataWeapon newWeapon)
    {
        if (currentWeapon != null)
        {
            DropCurrentWeapon();
        }
        NewCurrentWeapon(newWeapon);
    }

    private void DropCurrentWeapon()
    {
        if (currentWeapon == null)
        {
            return;
        }
        PoolingManager.Spawn(currentWeapon.dropWeapon, transform.position, Quaternion.identity);
    }

    private void NewCurrentWeapon(DataWeapon weapon)
    {
        currentWeapon = weapon;
        handWeapon.sprite = weapon.weaponSprite;
    }
}
