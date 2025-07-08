using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// 모든 화살에서 재사용

public class ArrowCreate : Singleton<ArrowCreate>
{
    [SerializeField] private GameObject arrowPrefab;  // 생성될 오브젝트
    [SerializeField] private Transform arrowParent;   // 생성될 위치

    private ObjectPool<GameObject> arrowPool;         // 오브젝트 풀 

    private void Start()
    {
        // 활 오브젝트 풀 초기화
        Init();
    }
    public void Init()
    {
        arrowPool = new ObjectPool<GameObject>(
            // 풀에 게임오브젝트가 없을 때 생성하는 람다식 함수
            createFunc: () =>
            {
                GameObject obj = Instantiate(arrowPrefab, arrowParent);
                ArrowInspector arrow = obj.GetComponent<ArrowInspector>();
                arrow.SetDespawnAction(() => DespawnArrow(arrow)); // 풀에 반환할 때 호출되는 작업 등록 (화살 자기 자신이 반환)
                return obj;
            },
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            defaultCapacity: 5,
            maxSize: 10
        );
    }

    // 오브젝트 풀에서 꺼내기
    public ArrowInspector SpawnArrow(Vector2 position, int damage)
    {
        GameObject obj = arrowPool.Get();
        obj.transform.position = position;
        ArrowInspector ins = obj.GetComponent<ArrowInspector>();
        ins.damage = damage;
        ins.direction = position;

        return obj.GetComponent<ArrowInspector>();
    }

    // 오브젝트 풀에다 반납하기 Arrow의 private Action onDespawn;에 등록된 함수
    public void DespawnArrow(ArrowInspector arrow)
    {
        arrowPool.Release(arrow.gameObject);
    }
}
