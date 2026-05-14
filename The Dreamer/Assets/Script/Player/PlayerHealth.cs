using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : ManagerDamage
{
    public ManagerEnermy managerEnermy;
    [SerializeField] ManagerGame managerGame;

    private Rigidbody2D rb;

    [HideInInspector] public bool isKnockback = false;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        base.Start();
        UpdateHeal();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateHeal();

        if (currentHealth <= 0)
        {
            managerGame.ResetGame();
        }
    }

    public void TakeDamage(int damage, Transform enemy)
    {
        base.TakeDamage(damage);
        UpdateHeal();

        Vector2 direction = (transform.position - enemy.position).normalized;
        StartCoroutine(ApplyKnockBack(direction));

        if (currentHealth <= 0)
        {
            managerGame.ResetGame();
        }
    }

    public override void AddHealth(int health)
    {
        base.AddHealth(health);
        UpdateHeal();
    }

    private void UpdateHeal()
    {
        managerEnermy.UpdateEnermy(currentHealth, maxHealth);
    }

    private IEnumerator ApplyKnockBack(Vector2 direction)
    {
        isKnockback = true;

        rb.velocity = direction * 5f;
        yield return new WaitForSeconds(0.15f);
        rb.velocity = Vector2.zero;

        isKnockback = false;
    }
}
