using UnityEngine;


// ������ �ޱ�

public interface IDamageable
{
    void TakeDamage(int damage);
}

// ��ü ���� - �÷��̾� ����
public interface IWeapon
{
    void TakeAttack(Vector2 direction, int damage);
}