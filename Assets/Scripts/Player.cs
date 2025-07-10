using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [SerializeField] int Movespeed;

    [SerializeField] Vector2 dir;

    [SerializeField] GameObject bullet;

    private Rigidbody2D rd;
    private SpriteRenderer sr;
    private Animator ani;
    public bool isShoot = false;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if (dir.x != 0) sr.flipX = dir.x == 1 ? false : true;

        dir = dir.normalized;

        if (Input.GetMouseButtonDown(0) && !isShoot)
        {
            StartCoroutine(ShootCoroutine());
        }

    }

    private void FixedUpdate()
    {

        rd.MovePosition(rd.position + dir * Movespeed * Time.deltaTime);

        ani.SetFloat("Speed", dir.magnitude);

    }

    private IEnumerator ShootCoroutine()
    {
        isShoot = true;

        // �ִϸ��̼� Ʈ����
        ani.SetTrigger("Shoot");

        // 0.3�� ���
        yield return new WaitForSeconds(0.5f);

        // ȭ�� �߻�
        Shoot();

        isShoot = false;
    }

    void Shoot()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        // ���� ����
        worldPos -= transform.position;
        
        // �ٶ󺸴� �������� ȸ��
        float angle = Mathf.Atan2(worldPos.y, worldPos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        GameObject newbullet = Instantiate(bullet);
        newbullet.transform.position = transform.position;
        newbullet.transform.rotation = rotation;
        newbullet.GetComponent<Bullet>().Dir = worldPos;
    }
}