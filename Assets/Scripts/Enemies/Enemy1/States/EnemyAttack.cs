using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : EnemyState
{
    public EnemyChase chase;

    [SerializeField] private Transform target;
    [SerializeField] private float chaseDistance;

    [SerializeField] private AIPath aiPath;

    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform movebackPoint;
    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, target.position) > chaseDistance)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            return chase;
        }

        if (Vector2.Distance(controller.transform.position, target.position) < 3f)
        {
            aiDestinationSetter.target = movebackPoint;
            aiPath.maxSpeed = controller.speed * 4f;
        }
        else
        {
            aiDestinationSetter.target = target;
            aiPath.maxSpeed = controller.speed * 2f;
        }

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            controller.transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            controller.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        //Attack Codes
        

        return this;
    }
}
