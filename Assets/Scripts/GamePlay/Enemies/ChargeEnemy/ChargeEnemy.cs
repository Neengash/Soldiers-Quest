using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : EnemyCommon
{
    [SerializeField] MonoBehaviour IddleState;
    [SerializeField] ChargeEnemyStates enemyStates;
    [SerializeField] GameObject attackArea;

    protected new void Start() {
        base.Start();
        attackArea.SetActive(false);
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void startAttack() {
        this.isAttacking = true;
    }

    public void ActivateAttackArea(bool status) {
        attackArea.SetActive(status);
    }

    public void PlayAudio(AudioClip audio) {
        audioSource.PlayOneShot(audio);
    }

    public override void HeroInSight() {
        EnemyStateI state = (EnemyStateI)enemyStates.getCurrentState();
        state.HeroInSight();
    }

    public override void HeroOutOfSight() {
        EnemyStateI state = (EnemyStateI)enemyStates.getCurrentState();
        state.HeroOutOfSight();
    }

    public override void HeroInRange() {
        EnemyStateI state = (EnemyStateI)enemyStates.getCurrentState();
        state.HeroInRange();
    }

    public override void HeroOutOfRange() {
        EnemyStateI state = (EnemyStateI)enemyStates.getCurrentState();
        state.HeroOutOfRange();
    }

    public override void Hurt() {
        enemyStates.ChangeState(IddleState);
        animator.SetBool(DIE, true);
        Die();
    }
}
