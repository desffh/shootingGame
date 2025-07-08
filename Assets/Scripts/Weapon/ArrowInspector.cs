using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Ǯ�� �ڵ� ��ȯ

public class ArrowInspector : MonoBehaviour
{
    private Action onDespawn;
    public Vector2 direction;
    [SerializeField] public int speed = 5;
    [SerializeField] public int damage = 0;

    // ������Ʈ Ǯ ��ȯ �̺�Ʈ�� ���
    public void SetDespawnAction(Action callback)
    {
        onDespawn = callback;
    }

    // ���Ϳ� �浹 �� & ���� �Ÿ� �̻� ���� ��
    public void Despawn()
    {
        onDespawn?.Invoke(); // Ǯ�� ������ �ݳ�
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
            // Ǯ�� ��ȯ
            Despawn();
        }
    }
}
