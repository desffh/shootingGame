using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 무기 공격 정보 변경 가능
public class PlayerWeapon : MonoBehaviour
{
    private IWeapon currentWeapon;

    // 기본 공격력
    [SerializeField] public int baseDamage = 10;

    // 추가 공격력
    [SerializeField] private float attackBuff = 1f;

    [Header("무기 설정")]
    [SerializeField] private Transform swordAttackPoint;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private ArrowCreate arrowPool;

    private void Start()
    {
        // 첫 시작은 검
        EquipSword();
    }
    public void EquipSword()
    {
        currentWeapon = new Sword(swordAttackPoint, 1.5f, baseDamage, enemyLayer);
        Debug.Log("검 상태에요");
    }

    public void EquipBow()
    {
        // 생성 위치, 데미지
        currentWeapon = new Arrow(arrowPool, baseDamage);
        Debug.Log("활 상태에요");
    }

    public void EquipAttack(Vector2 dir)
    {
        currentWeapon?.TakeAttack(dir, baseDamage);
    }
}
