using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float move_speed = 5;
    [SerializeField] private float HP;

    private Vector2 direction;

    private Rigidbody2D rigid;
    private Collider2D col;
    private SpriteRenderer sprite;
    private Animator anime;

    PlayerMovement movement;
    PlayerAnimator animator;
    PlayerHP playerHP;
    PlayerWeapon playerWeapon;

    private bool isAnimating = false;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();

        movement = new PlayerMovement(rigid, move_speed);
        animator = new PlayerAnimator(anime);
        playerHP = new PlayerHP();
        playerWeapon = GetComponent<PlayerWeapon>();
    }

    private void Start()
    {
        HP = playerHP.HP;
    }

    // ������ �Է¹ޱ�
    private void Update()
    {
        // ������ �Է¹ޱ�
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        // ���� �ٲٱ�
        if (direction.x != 0)   sprite.flipX = direction.x == 1 ? false : true;

        // �밢�� ����
        direction = direction.normalized;

        // ���� ���� ��ȯ
        if (Input.GetKeyDown(KeyCode.Alpha1)) playerWeapon.EquipSword();
        if (Input.GetKeyDown(KeyCode.Alpha2)) playerWeapon.EquipBow();

        // ZŰ ����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAnimating = true;
        }
    }

    // ���� ĳ���� �̵� (���� ����)
    private void FixedUpdate()
    {
        movement.Move(direction);
        //animator.IsWalk(directionX);

        // ���� �ִϸ��̼�
        if (isAnimating)
        {
            isAnimating = false;
            playerWeapon.EquipAttack(direction);
            //animator.IsAttack();
        }
    }

    public void TakeDamage(int damage)
    {
        playerHP.Damage(damage);
        HP = playerHP.HP;
    }
}
