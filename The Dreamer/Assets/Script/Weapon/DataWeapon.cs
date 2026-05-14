using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWeapon", menuName = "The Dreamer/Weapon Data")]
public class DataWeapon : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    public GameObject dropWeapon;
    public float speed;
    public int damage;
    public int enermyLost; //tiêu hao năng lượng
    public float radiate; //Độ tỏa
    public int quantity; //Số lượng mỗi lần bắn

    public float loadTime;

    public GameObject SpriteBullet;
}
