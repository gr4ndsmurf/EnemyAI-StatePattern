using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2StateMachine : MonoBehaviour
{
    public Enemy2State currentState;
    public Enemy2Controller controller;

    private void Start()
    {
        controller = GetComponent<Enemy2Controller>();
    }

    private void Update()
    {
        Enemy2State state = currentState.State(controller);
        if (currentState != null)
        {
            currentState = state;
        }
    }
}
