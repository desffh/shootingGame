using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ���� ���� ���� ���� ����
public class PlayerWeapon : MonoBehaviour
{
    private IWeapon currentWeapon;

    // �⺻ ���ݷ�
    [SerializeField] public int baseDamage = 10;

    // �߰� ���ݷ�
    [SerializeField] private float attackBuff = 1f;

    [Header("���� ����")]
    [SerializeField] private Transform swordAttackPoint;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private ArrowCreate arrowPool;

    private void Start()
    {
        // ù ������ ��
        EquipSword();
    }
    public void EquipSword()
    {
        currentWeapon = new Sword(swordAttackPoint, 1.5f, baseDamage, enemyLayer);
        Debug.Log("�� ���¿���");
    }

    public void EquipBow()
    {
        // ���� ��ġ, ������
        currentWeapon = new Arrow(arrowPool, baseDamage);
        Debug.Log("Ȱ ���¿���");
    }

    public void EquipAttack(Vector2 dir)
    {
        currentWeapon?.TakeAttack(dir, baseDamage);
    }
}
