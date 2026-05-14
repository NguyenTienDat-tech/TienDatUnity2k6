using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyTamXa : EnemyBase
{
    [SerializeField] DataWeapon currentWeapon;

    [SerializeField] Transform gunTransform; //vị trí súng
    [SerializeField] Transform firePoint; //vị trí đạn ra

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

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < enemyStatus.attackRange && canAttack)
        {
            StartCoroutine(AttackGun());
        }

        if (distance < enemyStatus.attackRange - 0.1f)
        {
            MoveAwayFromPlayer();
        }
        else
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

    private void RotationWeaponToPlayer()
    {
        Vector2 direction = player.position - gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0, 0, angle);

        if (gunTransform.transform.eulerAngles.z > 90 && gunTransform.transform.eulerAngles.z < 270)
        {
            gunTransform.transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            gunTransform.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator AttackGun()
    {
        isAttack = true;
        canAttack = false;
        StopMove();

        for (int i = 0; i < currentWeapon.quantity; i++)
        {
            //Độ tỏa của đạn
            float currentAngle = firePoint.eulerAngles.z;
            float random = Random.Range(-currentWeapon.radiate, currentWeapon.radiate);
            Quaternion bulletRotation = Quaternion.Euler(0, 0, currentAngle + random);


            //Spawn đạn
            GameObject bullet = PoolingManager.Spawn(currentWeapon.SpriteBullet, firePoint.position, bulletRotation);
            Bullet spriteBullet = bullet.GetComponent<Bullet>();
            if (bullet != null)
            {
                spriteBullet.Setup(currentWeapon.speed, currentWeapon.damage);
            }
        }
        gunTransform.transform.DOLocalMoveX(-0.2f, 0.05f).OnComplete(() => gunTransform.transform.DOLocalMoveX(0, 0.05f));

        yield return new WaitForSeconds(enemyStatus.attackCoolDown);
        canAttack = true;
        isAttack = false;
    }


}
