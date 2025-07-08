using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ork : Monster, IDamageable
{
    private void Start()
    {
        AttackDamage = 5;
        AttackRange = 3;
        HP = 20;
    }
    public override void TakeAttack(int count)
    {
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            // Á×À½;
        }
    }
}
