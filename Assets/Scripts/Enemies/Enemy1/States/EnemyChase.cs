using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyIdle idle;
    public EnemyAttack attack;

    public override EnemyState State(EnemyController controller)
    {
        if (!true)
        {
            controller.animator.SetBool("Chase", false);
            return idle;
        }
        else if (true)
        {
            controller.animator.SetBool("Attack", true);
            return attack;
        }

        //Chase Codes

        return this;
    }
}
