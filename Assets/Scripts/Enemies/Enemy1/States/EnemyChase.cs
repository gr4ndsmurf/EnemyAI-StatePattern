using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public EnemyAttack attack;

    [SerializeField] private float attackDistance;
    [SerializeField] private Transform target;
    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, target.position) < attackDistance)
        {
            controller.animator.SetBool("Attack", true);
            return attack;
        }

        //Chase Codes

        return this;
    }
}
