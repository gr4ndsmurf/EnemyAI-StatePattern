using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy2State : MonoBehaviour
{
    public abstract Enemy2State State(Enemy2Controller controller); 
}
