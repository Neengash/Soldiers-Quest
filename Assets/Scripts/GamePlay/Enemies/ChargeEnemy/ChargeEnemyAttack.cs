using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyAttack : MonoBehaviour, EnemyStateI
{
    [SerializeField] ChargeEnemyStates enemystate;
    [SerializeField] MonoBehaviour chargeEnemyIddle;
    [SerializeField] MonoBehaviour chargeEnemyRun;
    [SerializeField] ChargeEnemy enemy;
    [SerializeField] AudioClip attackSound;

    protected bool inSight, inRange;

    private void OnEnable() {
        enemy.getAnimator().SetBool(EnemyCommon.ATTACK, true);
        enemy.startAttack();
        inSight = false;
        inRange = true;
    }

    private void OnDisable() {
        enemy.getAnimator().SetBool(EnemyCommon.ATTACK, false);
    }

    private void Update()
    {
        if (!enemy.IsAttacking()) {
            if (!inSight) {
                enemystate.ChangeState(chargeEnemyIddle);
            } else if (!inRange) {
                enemystate.ChangeState(chargeEnemyRun);
            } else {
                enemy.startAttack();
            }
        }
    }

    public void ActivateAttack() {
        enemy.ActivateAttackArea(true);
        enemy.PlayAudio(attackSound);
    }

    public void DeactivateAttack() {
        enemy.ActivateAttackArea(false);
    }

    public void HeroInRange() {
        inRange = true;
    }

    public void HeroInSight() {
        inSight = true;
    } 

    public void HeroOutOfRange() {
        inRange = false;
    }

    public void HeroOutOfSight() {
        inSight = false;
    }
}
