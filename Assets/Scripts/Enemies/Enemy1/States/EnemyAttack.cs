using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyChase chase;

    [SerializeField] private Transform target;
    [SerializeField] private float chaseDistance;
    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, target.position) > chaseDistance)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            return chase;
        }

        //Attack Codes

        return this;
    }
}
