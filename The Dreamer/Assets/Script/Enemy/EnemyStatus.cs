using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy/Stats")]
public class EnemyStatus : ScriptableObject
{
    public int healEnemy = 100;
    public float speed = 2f;
    public int damage = 10;

    public float attackRadius = 1.0f; // bán kính tấn công
    public float attackRange = 1.5f;   // Tầm đánh
    public float attackCoolDown = 2f;  // thời gian hồi chiêu


    public float daskSpeed = 18f;
    public float daskCoolDown = 5f;
    public float daskDuration = 0.3f;
}
