using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : IWeapon
{
    private Transform attackPoint;
    private float attackRange;
    private int damage;
    private LayerMask enemyLayer;

    public Sword(Transform attackPoint, float range, int damage, LayerMask layer)
    {
        this.attackPoint = attackPoint;
        this.attackRange = range;
        this.damage = damage;
        this.enemyLayer = layer;
    }
    public void TakeAttack(Vector2 dir, int damage)
    {
        Debug.Log("°Ë ¾²±â");
    }
}
