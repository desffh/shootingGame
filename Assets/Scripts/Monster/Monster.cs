using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    // ���� ���� ��ũ���ͺ� ������Ʈ�� ����
    [SerializeField] protected float AttackRange;  // ���� �ֱ�
    [SerializeField] protected float AttackDamage; // ���� ������
    [SerializeField] protected float HP;           // ü��

    public virtual void TakeAttack(int attack)
    {
        // ���� ó��
    }
   
}
