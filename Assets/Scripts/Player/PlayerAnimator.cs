using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator
{
    readonly private Animator animator;

    public PlayerAnimator(Animator anime)
    {
        animator = anime;
    }

    public void IsWalk(float direction)
    {
        animator.SetFloat("Walk", Mathf.Abs(direction));
    }

    public void IsAttack()
    {
        animator.SetTrigger("Attack");
    }
}
