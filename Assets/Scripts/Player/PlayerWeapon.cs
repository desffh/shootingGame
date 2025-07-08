using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 무기 공격 정보 변경 가능
public class PlayerWeapon : MonoBehaviour
{
    private IWeapon currentWeapon;

    // 기본 공격력
    [SerializeField] private int baseDamage = 10;

    // 추가 공격력
    [SerializeField] private float attackBuff = 1f;

    [Header("무기 관련")]
    [SerializeField] private Transform swordPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowPoint;

    private void Start()
    {
        // 첫 시작은 검
        EquipSword();
    }
    public void EquipSword()
    {
        currentWeapon = new Sword();
        Debug.Log("검 상태에요");
    }

    public void EquipBow()
    {
        currentWeapon = new Arrow();
        Debug.Log("활 상태에요");
    }

    public void EquipAttack()
    {
        //int finalDamage = Mathf.RoundToInt(baseAttackDamage * attackMultiplier);
        //currentWeapon?.TakeAttack(finalDamage);
    }
}
