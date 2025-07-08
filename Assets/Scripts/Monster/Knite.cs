using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knite : Monster, IDamageable
{
    private void Start()
    {
        AttackDamage = 10;
        AttackRange = 5;
        HP = 30;
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
