using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyChase chase;
    public override EnemyState State(EnemyController controller)
    {
        if (true)
        {
            controller.animator.SetBool("Chase", true);
            return chase;
        }

        // idle codes

        return this;
    }
}
