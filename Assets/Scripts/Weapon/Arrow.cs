using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : IWeapon
{
    // 활 데미지, 이동 속도, 
    private ArrowCreate pool;
    private int damage;

    public Arrow(ArrowCreate pool, int damage)
    {
        this.pool = pool;
        this.damage = damage;
    }

    public void TakeAttack(Vector2 dir, int damage)
    {
        Debug.Log("활 쏘기");

        // 오브젝트 풀 꺼내기
        ArrowInspector arrow = pool.SpawnArrow(dir, damage);
    }
}
