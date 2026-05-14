using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BossControl : BaseBoss
{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject gateNextLever;
    [SerializeField] GameObject heal;


    [SerializeField] DataWeapon currentWeapon;

    [SerializeField] Transform gunTransform;
    [SerializeField] Transform firePoint;

    

    private bool isAttack;


    protected override void Start()
    {
        base.Start();
        heal.SetActive(true);
    }
    protected override void Update()
    {
        RotationWeaponToPlayer();

        if (currentHealth > maxHealth / 2)
        {
            enemyStatus.speed = 1.5f;
            enemyStatus.attackRange = 5;
            enemyStatus.attackCoolDown = 0.5f;
            enemyStatus.daskCoolDown = 2f;
        }

        if (currentHealth <= maxHealth / 2)
        {
            enemyStatus.speed = 2.5f;
            enemyStatus.attackCoolDown = 0.1f;
            enemyStatus.daskCoolDown = 1f;
        }

        if (currentHealth <= 0)
        {
            npc.SetActive(true);
            gateNextLever.SetActive(true);
            heal.SetActive(false);
            return;
        }

        if (isAttack)
        {
            StopMove();
        }

        if (isKnockBack || isDask)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= enemyStatus.attackRange && canAttack)
        {
            StartCoroutine(AttackGun());
        }

        if (distance > enemyStatus.attackRange)
        {
            MoveToPlayer();
        }
        else if (distance < enemyStatus.attackRange - 0.1f)
        {
            MoveAwayFromPlayer();
        }
        else
        {
            StopMove();
        }

        daskCoolDown();
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
