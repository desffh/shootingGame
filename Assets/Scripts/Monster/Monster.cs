using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    // 추후 몬스터 스크립터블 오브젝트로 관리
    [SerializeField] protected float AttackRange;  // 공격 주기
    [SerializeField] protected float AttackDamage; // 공격 데미지
    [SerializeField] protected float HP;           // 체력

    public virtual void TakeAttack(int attack)
    {
        // 공격 처리
    }
   
}
