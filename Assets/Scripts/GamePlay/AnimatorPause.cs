using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPause : MonoBehaviour
{
    // Every object with an animator should also have the AnimatorPause Script

    Animator animator;
    float animatorSpeed;
    const float STOP = 0f;

    PauseController game;
    GameOverController gameOver;

    void Start()
    {
        game = FindObjectOfType<PauseController>();
        gameOver = FindObjectOfType<GameOverController>();
        animator = GetComponent<Animator>();
        animatorSpeed = animator.speed;
    }

    void Update()
    {
        if (animator.speed != STOP && game.IsPaused()) {
            animator.speed = STOP;
        } else if (animator.speed == STOP && !game.IsPaused() && !gameOver.isGameOver) {
            animator.speed = animatorSpeed;
        }
    }
}
