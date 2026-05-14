using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDamage : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public virtual void AddEnermy(int Enermy)
    {
        currentHealth += Enermy;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void AddHealth(int Health)
    {
        currentHealth += Health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public bool HasEnoughEnergy(int cost)
    {
        return currentHealth >= cost;
    }
}