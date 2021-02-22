using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeenemyRun : MonoBehaviour, EnemyStateI
{
    [SerializeField] ChargeEnemyStates enemystate;
    [SerializeField] MonoBehaviour chargeEnemyIddle;
    [SerializeField] MonoBehaviour chargeEnemyAttack;
    [SerializeField] ChargeEnemy enemy;

    public const string RUN = "run";

    private void OnEnable() {
        enemy.setDirection(EnemyCommon.LEFT);
        enemy.setSpeed(EnemyCommon.BASE_SPEED);
        enemy.getAnimator().SetBool(RUN, true);
    }

    private void OnDisable() {
        enemy.getAnimator().SetBool(RUN, false);
        enemy.setSpeed(0);
    }

    private void FixedUpdate() {
        enemy.ApplyMovement();
    }

    public void HeroInRange() {
        enemystate.ChangeState(chargeEnemyAttack);
    }

    public void HeroInSight() { /** Do Nothing **/ }

    public void HeroOutOfRange() { /** Do Nothing **/ }

    public void HeroOutOfSight() {
        enemystate.ChangeState(chargeEnemyIddle);
    }
}
