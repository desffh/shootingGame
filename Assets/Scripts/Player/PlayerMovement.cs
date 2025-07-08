using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private readonly Rigidbody2D rigid;
    private readonly float movespeed;


    public PlayerMovement(Rigidbody2D rigid, float movespeed)
    {
        this.rigid = rigid;
        this.movespeed = movespeed;
    }

    // 좌우 이동
    public void Move(Vector2 direction)
    {
        // 물리 이동
        rigid.MovePosition(rigid.position + direction * movespeed * Time.fixedDeltaTime);
    }
}
