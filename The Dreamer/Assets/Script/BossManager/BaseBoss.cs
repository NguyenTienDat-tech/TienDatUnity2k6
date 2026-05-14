using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BaseBoss : ManagerDamage
{
    [SerializeField] GameObject prefadItemDrop;
    [SerializeField] int dropEnermyCount = 3;

    public ManagerEnermy managerHealBoss;

    [SerializeField] protected EnemyStatus enemyStatus;

    protected Transform player;

    [SerializeField] protected Transform swordTransform;

    protected bool canAttack = true;
    protected bool isDeath = false;
    protected bool isKnockBack = false;


    protected Animator animator;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;

    [HideInInspector] public Room room;

    private float daskTime;
    protected bool isDask;


    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        maxHealth = enemyStatus.healEnemy;
        currentHealth = maxHealth;
        UpdateHeal();

        GameObject find = GameObject.FindGameObjectWithTag("Player");
        if (find != null)
        {
            player = find.transform;
        }

        daskTime = enemyStatus.daskCoolDown;
    }

    protected virtual void Update()
    {
        if (isDeath || player == null)
        {
            return;
        }
    }

    protected void MoveToPlayer()
    {
        if (isKnockBack)
        {
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * enemyStatus.speed;

        animator.SetFloat("moveX", direction.x);
        animator.SetBool("isMove", true);
    }

    protected void MoveAwayFromPlayer()
    {
        if (isKnockBack)
        {
            return;
        }

        Vector2 direction = (transform.position - player.position).normalized;
        rb.velocity = direction * enemyStatus.speed;

        animator.SetFloat("moveX", direction.x);
        animator.SetBool("isMove", true);
    }

    protected void StopMove()
    {
        Vector2 direction = (transform.position - player.position).normalized;
        rb.velocity = new Vector2(-direction.y, direction.x) * enemyStatus.speed;
        animator.SetBool("isMove", false);
    }

    public override void TakeDamage(int damage)
    {
        if (isDeath)
        {
            return;
        }

        base.TakeDamage(damage);

        Vector2 autoKnockbackDir = (transform.position - player.position).normalized;
        StartCoroutine(ApplyKnockBack(autoKnockbackDir));


        StartCoroutine(FlashEffect());

        if (currentHealth <= 0)
        {
            AnimationDie();
        }
        UpdateHeal();
    }

    private void AnimationDie()
    {
        isDeath = true;
        StopMove();

        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;

        StopAllCoroutines();

        animator.SetTrigger("Death");
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);

        if (room != null)
        {
            room.RemoveBoss(this);
        }


        for (int i = 0; i < dropEnermyCount; i++)
        {
            PoolingManager.Spawn(prefadItemDrop, transform.position, Quaternion.identity);
        }
        PoolingManager.Despawn(gameObject);
    }

    private IEnumerator ApplyKnockBack(Vector2 direction)
    {
        isKnockBack = true;
        rb.velocity = direction * 5f;
        yield return new WaitForSeconds(0.15f);
        rb.velocity = Vector2.zero;
        isKnockBack = false;
    }

    private IEnumerator FlashEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    protected void daskCoolDown()
    {
        if (isDask)
        {
            return;
        }

        daskTime -= Time.deltaTime;

        if (daskTime <= 0)
        {
            StartCoroutine(daskRoutine());
            daskTime = enemyStatus.daskCoolDown;
        }
    }

    private IEnumerator daskRoutine()
    {
        isDask = true;
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * enemyStatus.daskSpeed;

        yield return new WaitForSeconds(enemyStatus.daskDuration);

        rb.velocity = Vector2.zero;
        isDask = false;

    }

    public void UpdateHeal()
    {
        managerHealBoss.UpdateEnermy(currentHealth, maxHealth);
    }

}