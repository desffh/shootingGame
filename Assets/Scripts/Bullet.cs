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
        // 코루틴 시작
        // 비활성화 됐을 때 코루틴을 바로 종료하기 위해서 변수에 저장
        deactivateCoroutine = StartCoroutine(AutoDeactivate());
    }

    void OnDisable()
    {
        // 비활성화 시 코루틴 바로 중단
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
