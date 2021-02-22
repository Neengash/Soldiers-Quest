using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{

    HeroGameController hero;
    Rigidbody2D rBody2D;
    Animator animator;

    // Animator parameters
    const string IDLE = "idle";
    const string WALK = "walk";
    const string JUMP = "jump";
    const string FALL = "fall";
    const string ATTACK = "attack";
    const string DIE = "die";

    void Start()
    {
        hero = GetComponent<HeroGameController>();
        rBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsStill()) {
            animator.SetBool(IDLE, true);
        } else {
            animator.SetBool(IDLE, false);
        }

        if (IsWalking()) {
            animator.SetBool(WALK, true);
        } else {
            animator.SetBool(WALK, false);
        }

        if (IsJumping()) {
            animator.SetBool(JUMP, true);
        } else {
            animator.SetBool(JUMP, false);
        }

        if (IsFalling()) {
            animator.SetBool(FALL, true);
        } else {
            animator.SetBool(FALL, false);
        }

        if (IsAttacking()) {
            animator.SetBool(ATTACK, true);
        } else {
            animator.SetBool(ATTACK, false);
        }

        if (IsDead()) {
            animator.SetBool(DIE, true);
        }
    }

    private bool IsStill() {
        return hero.onFloor && !hero.IsMoving() && !hero.isDead;
    }

    private bool IsWalking() {
        return hero.onFloor && hero.IsMoving() && !hero.isDead;
    }

    private bool IsJumping() {
        return !hero.onFloor && rBody2D.velocity.y > 0f && !hero.isDead;
    }

    private bool IsFalling() {
        return !hero.onFloor && rBody2D.velocity.y < 0f && !hero.isDead;
    }

    private bool IsAttacking() {
        return hero.isAttacking && !hero.isDead;
    }

    private bool IsDead() {
        return hero.isDead;
    }

    public void StopAnimaiton() {
        animator.speed = 0;
    }
}
