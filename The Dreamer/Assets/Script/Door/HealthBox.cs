using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : ManagerDamage
{
    [SerializeField] ManagerHealEnemy healBox;

    protected override void Start()
    {
        base.Start();
        UpdateHeal();
    }

    public override void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        base.TakeDamage(damage);
        UpdateHeal();

        if (currentHealth <= 0)
        {
            PoolingManager.Despawn(gameObject);
        }

    }

    private void UpdateHeal()
    {
        healBox.UpdateEnemy(currentHealth, maxHealth);
    }
}
