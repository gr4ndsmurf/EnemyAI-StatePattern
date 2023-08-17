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

        //Look at target
        Vector2 direction = new Vector2(target.transform.position.x - controller.transform.position.x, target.transform.position.y - controller.transform.position.y);
        controller.transform.up = Vector3.Lerp(controller.transform.up, direction, controller.damping);

        //Chase

        return this;
    }
}
