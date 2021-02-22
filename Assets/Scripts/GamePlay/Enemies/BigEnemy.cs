using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyCommon
{

    int health;
    [SerializeField] GameObject attackArea;
    [SerializeField] GameObject wound;

    protected new void Start()
    {
        base.Start();

        health = 3;
    }

    void Update()
    {
        if (dead) {
            animator.SetBool(DIE, true);
            return;
        }

        animator.SetBool(ATTACK, attack);
    }

    public override void HeroInSight() { /* This enemy doesn't use Sight */ }

    public override void HeroOutOfSight() { /* This enemy doesn't use Sight */ }

    public override void HeroInRange() {
        attack = true;
    }

    public override void HeroOutOfRange() {
        attack = false;
    }

    public override void Hurt() {
        health--;
        if (health == 0) {
            Die();
        } else {
            audioSource.PlayOneShot(hurtSound);
            wound.SetActive(true);
        }
    }

    public void ActivateAttack()
    {
        attackArea.SetActive(true);
        audioSource.PlayOneShot(attackSound);
    }

    public void DeactivateAttack()
    {
        attackArea.SetActive(false);
    }
}
