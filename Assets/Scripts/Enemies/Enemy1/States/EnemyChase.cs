using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    [SerializeField] private float attackDistance = 5f;

    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, controller.target.position) < attackDistance)
        {
            controller.animator.SetBool("Attack", true);
            return controller.attack;
        }

        //Look at target
        Vector2 direction = new Vector2(controller.target.transform.position.x - controller.transform.position.x, controller.target.transform.position.y - controller.transform.position.y);
        controller.transform.up = Vector3.Lerp(controller.transform.up, direction, controller.damping);

        //Chase

        return this;
    }
}
