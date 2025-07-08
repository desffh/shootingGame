using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// ��� ȭ�쿡�� ����

public class ArrowCreate : Singleton<ArrowCreate>
{
    [SerializeField] private GameObject arrowPrefab;  // ������ ������Ʈ
    [SerializeField] private Transform arrowParent;   // ������ ��ġ

    private ObjectPool<GameObject> arrowPool;         // ������Ʈ Ǯ 

    private void Start()
    {
        // Ȱ ������Ʈ Ǯ �ʱ�ȭ
        Init();
    }
    public void Init()
    {
        arrowPool = new ObjectPool<GameObject>(
            // Ǯ�� ���ӿ�����Ʈ�� ���� �� �����ϴ� ���ٽ� �Լ�
            createFunc: () =>
            {
                GameObject obj = Instantiate(arrowPrefab, arrowParent);
                ArrowInspector arrow = obj.GetComponent<ArrowInspector>();
                arrow.SetDespawnAction(() => DespawnArrow(arrow)); // Ǯ�� ��ȯ�� �� ȣ��Ǵ� �۾� ��� (ȭ�� �ڱ� �ڽ��� ��ȯ)
                return obj;
            },
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            defaultCapacity: 5,
            maxSize: 10
        );
    }

    // ������Ʈ Ǯ���� ������
    public ArrowInspector SpawnArrow(Vector2 position, int damage)
    {
        GameObject obj = arrowPool.Get();
        obj.transform.position = position;
        ArrowInspector ins = obj.GetComponent<ArrowInspector>();
        ins.damage = damage;
        ins.direction = position;

        return obj.GetComponent<ArrowInspector>();
    }

    // ������Ʈ Ǯ���� �ݳ��ϱ� Arrow�� private Action onDespawn;�� ��ϵ� �Լ�
    public void DespawnArrow(ArrowInspector arrow)
    {
        arrowPool.Release(arrow.gameObject);
    }
}
