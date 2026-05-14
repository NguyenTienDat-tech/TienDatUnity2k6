using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEnermy : ManagerDamage
{
    public ManagerEnermy ManagerEnermy;

    protected override void Start()
    {
        base.Start();
        UpdateHeal();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateHeal();
    }

    public override void AddEnermy(int Enermy)
    {
        base.AddEnermy(Enermy);
        UpdateHeal();
    }



    private void UpdateHeal()
    {
        ManagerEnermy.UpdateEnermy(currentHealth, maxHealth);
    }


   
}
