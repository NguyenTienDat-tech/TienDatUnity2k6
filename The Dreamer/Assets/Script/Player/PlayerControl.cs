using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    public Vector2 movement;
    private Rigidbody2D rb;
    private PlayerHealth heal;
    private PlayerParry parry;


    [SerializeField] private float daskSpeed = 20f; // tốc độ lướt
    [SerializeField] private float daskDuration = 0.2f; // thời gian lướt
    [SerializeField] private float daskCoolDown = 1f; //thời gian hồi chiêu

    private bool isDask = false; // kiểm tra lướt thì không di chuyển
    private bool isCoolDown = true; //kiểm tra hồi chiêu

    private TrailRenderer trailRenderer;
    [HideInInspector] public EnemyStatus enemyStatus;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heal = GetComponent<PlayerHealth>();
        parry = GetComponent<PlayerParry>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void MovementPlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }



    private void Update()
    {
        if (isDask) return;
        if (heal.isKnockback) return;

        MovementPlayer();

        if (Input.GetKeyDown(KeyCode.Space) && isCoolDown)
        {
            StartCoroutine(daskSkill());
        }

    }

    private void FixedUpdate()
    {
        if (isDask) return;

        rb.velocity = movement.normalized * moveSpeed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletofEnemy"))
        {
            if (parry.liveParry > 0)
            {
                parry.ManagerParry();
            }
            else
            {
                heal.TakeDamage(enemyStatus.damage, collision.transform);
            }
            PoolingManager.Despawn(collision.gameObject);
        }
    }


    private IEnumerator daskSkill()
    {
        isCoolDown = false;
        isDask = true;

        rb.velocity = movement * daskSpeed;

        trailRenderer.emitting = true;

        yield return new WaitForSeconds(daskDuration);

        trailRenderer.emitting = false;
        isDask = false;

        yield return new WaitForSeconds(daskCoolDown);
        isCoolDown = true;
    }



}
