using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState currentState;
    public EnemyController controller;

    private void Start()
    {
        controller = GetComponent<EnemyController>();
    }

    private void Update()
    {
        EnemyState state = currentState.State(controller);
        if (currentState != null)
        {
            currentState = state;
        }
    }
}
