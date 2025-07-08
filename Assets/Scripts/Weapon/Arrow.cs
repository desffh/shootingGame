using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : IWeapon
{
    // Ȱ ������, �̵� �ӵ�, 
    private ArrowCreate pool;
    private int damage;

    public Arrow(ArrowCreate pool, int damage)
    {
        this.pool = pool;
        this.damage = damage;
    }

    public void TakeAttack(Vector2 dir, int damage)
    {
        Debug.Log("Ȱ ���");

        // ������Ʈ Ǯ ������
        ArrowInspector arrow = pool.SpawnArrow(dir, damage);
    }
}
