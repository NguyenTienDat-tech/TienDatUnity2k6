using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEditor.FilePathAttribute;

public class EnemyTamGan : EnemyBase
{ 
    [SerializeField] Transform attackPoint; //vị trí tấn công
    [SerializeField] Transform handWeapon;
    [SerializeField] LayerMask playerLayer;

    private bool isAttack;



    protected override void Update()
    {
        RotationWeaponToPlayer();

        if (isAttack)
        {
            StopMove();
            return;
        }

        if (isKnockBack)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < enemyStatus.attackRange)
        {
            StopMove();

            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }
        if (distance > enemyStatus.attackRange)
        {
            MoveToPlayer();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
            PoolingManager.Despawn(collision.gameObject);
        }
    }

    private IEnumerator Attack()
    {
        isAttack = true;
        canAttack = false;
        StopMove();

        //hiện chưa có animation chém

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, enemyStatus.attackRadius, playerLayer);

        foreach (var target in hitPlayer)
        {
            PlayerParry parry = target.GetComponent<PlayerParry>();
            if (parry != null && parry.liveParry > 0)
            {
                parry.ManagerParry();
                continue;
            }

            PlayerHealth health = target.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(enemyStatus.damage, transform);
            }
        }

        yield return new WaitForSeconds(enemyStatus.attackCoolDown);
        canAttack = true;
        isAttack = false;
    }

    private void RotationWeaponToPlayer()
    {
        Vector2 direction = (player.position - handWeapon.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        handWeapon.rotation = Quaternion.Euler(0, 0, angle);

        if (handWeapon.transform.eulerAngles.z > 90 && handWeapon.transform.eulerAngles.z < 270)
        {
            handWeapon.transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            handWeapon.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}