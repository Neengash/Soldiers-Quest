using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyStates : MonoBehaviour
{
    [SerializeField] MonoBehaviour startState;
    [SerializeField] MonoBehaviour currentState;

    void Start()
    {
        startState.enabled = true;
        currentState = startState;
    }

    public void ChangeState(MonoBehaviour newState)
    {
        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }

    public MonoBehaviour getCurrentState()
    {
        return currentState;
    }
}
