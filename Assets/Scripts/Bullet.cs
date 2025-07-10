using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] int damage = 5;

    private Vector2 dir;

    public Vector2 Dir
    {
        get { return dir; }

        set { dir = value.normalized; }
    }


    private Coroutine deactivateCoroutine;

    public void SetDirection(Vector2 dir)
    {
        this.dir = dir.normalized;
    }

    void OnEnable()
    {
        // �ڷ�ƾ ����
        // ��Ȱ��ȭ ���� �� �ڷ�ƾ�� �ٷ� �����ϱ� ���ؼ� ������ ����
        deactivateCoroutine = StartCoroutine(AutoDeactivate());
    }

    void OnDisable()
    {
        // ��Ȱ��ȭ �� �ڷ�ƾ �ٷ� �ߴ�
        if (deactivateCoroutine != null)
        {
            StopCoroutine(deactivateCoroutine);
            deactivateCoroutine = null;
        }
    }

    private IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
}
