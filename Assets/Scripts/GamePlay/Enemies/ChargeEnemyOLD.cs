using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyOLD : EnemyCommon
{
    bool inSight;
    const string RUN = "run";

    [SerializeField] GameObject attackArea;

    protected new void Start()
    {
        base.Start();

        direction = LEFT;
        speed = 0;
        inSight = false;
        attackArea.SetActive(false);
    }

    void Update()
    {
        if (dead) {
            animator.SetBool(DIE, true);
            return;
        }

        if (attack) {
            animator.SetBool(ATTACK, true);
            isAttacking = true;
        } else {
            animator.SetBool(ATTACK, false);
            animator.SetBool(RUN, inSight);
        }
    }

    private void FixedUpdate()
    {
        if (!isAttacking && !dead && speed != 0) {
            ApplyMovement();
        }
    }

    public override void HeroInRange()
    {
        attack = true;
        isAttacking = true;
    }

    public override void HeroOutOfRange()
    {
        attack = false;
    }

    public override void Hurt() {
        Die();
    }
    public override void HeroInSight()
    {
        inSight = true;
        speed = BASE_SPEED;
    }

    public override void HeroOutOfSight()
    {
        inSight = false;
        speed = 0;
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
