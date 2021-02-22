using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator animator;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        MoveRight();
    }

    public void MoveRight()
    {
        sprite.flipX = false;
        animator.SetBool("walk", true);
    }

    public void MoveLeft()
    {
        sprite.flipX = true;
        animator.SetBool("walk", true);
    }

    public void Stop()
    {
        animator.SetBool("walk", false);
    }

}
