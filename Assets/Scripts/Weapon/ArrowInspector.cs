using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 풀에 자동 반환

public class ArrowInspector : MonoBehaviour
{
    private Action onDespawn;
    public Vector2 direction;
    [SerializeField] public int speed = 5;
    [SerializeField] public int damage = 0;

    // 오브젝트 풀 반환 이벤트를 등록
    public void SetDespawnAction(Action callback)
    {
        onDespawn = callback;
    }

    // 몬스터와 충돌 시 & 일정 거리 이상 도달 시
    public void Despawn()
    {
        onDespawn?.Invoke(); // 풀에 스스로 반납
    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        // transform.Translate(Vector2.right * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var target = col.GetComponent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(damage);
            // 풀에 반환
            Despawn();
        }
    }
}
