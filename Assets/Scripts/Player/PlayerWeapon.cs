using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ���� ���� ���� ���� ����
public class PlayerWeapon : MonoBehaviour
{
    private IWeapon currentWeapon;

    // �⺻ ���ݷ�
    [SerializeField] private int baseDamage = 10;

    // �߰� ���ݷ�
    [SerializeField] private float attackBuff = 1f;

    [Header("���� ����")]
    [SerializeField] private Transform swordPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowPoint;

    private void Start()
    {
        // ù ������ ��
        EquipSword();
    }
    public void EquipSword()
    {
        currentWeapon = new Sword();
        Debug.Log("�� ���¿���");
    }

    public void EquipBow()
    {
        currentWeapon = new Arrow();
        Debug.Log("Ȱ ���¿���");
    }

    public void EquipAttack()
    {
        //int finalDamage = Mathf.RoundToInt(baseAttackDamage * attackMultiplier);
        //currentWeapon?.TakeAttack(finalDamage);
    }
}
