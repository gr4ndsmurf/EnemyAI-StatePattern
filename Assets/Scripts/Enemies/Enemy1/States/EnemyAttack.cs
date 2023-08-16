using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyChase chase;

    public override EnemyState State(EnemyController controller)
    {
        if (!true)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            return chase;
        }

        //Attack Codes

        return this;
    }
}
