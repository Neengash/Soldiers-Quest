using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyIddle : MonoBehaviour, EnemyStateI
{
    [SerializeField] ChargeEnemyStates enemystate;
    [SerializeField] MonoBehaviour chargeEnemyRun;
    [SerializeField] MonoBehaviour chargeEnemyAttack;

    public void HeroInRange() {
        enemystate.ChangeState(chargeEnemyAttack);
    }

    public void HeroInSight() {
        enemystate.ChangeState(chargeEnemyRun);
    }

    public void HeroOutOfRange() { /** Do nothing **/ }
    public void HeroOutOfSight() { /** Do nothing **/ }
}
