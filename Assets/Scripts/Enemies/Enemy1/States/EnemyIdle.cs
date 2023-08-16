using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    [Header("Chase")]
    [SerializeField] private EnemyChase chase;
    [SerializeField] private Transform target;
    [SerializeField] private float chaseDistance;

    [Header("Patrol")]
    [SerializeField] private Transform[] patrolPoints;

    private int patrolDestination;
    
    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, target.position) < chaseDistance)
        {
            controller.animator.SetBool("Chase", true);
            return chase;
        }

        if (patrolDestination == 0)
        {
            controller.transform.position = Vector2.MoveTowards(controller.transform.position, patrolPoints[0].position, controller.speed * Time.deltaTime);
            if (Vector2.Distance(controller.transform.position, patrolPoints[0].position) < .2f)
            {
                patrolDestination = 1;
                Flip();
            }
        }
        else if (patrolDestination == 1)
        {
            controller.transform.position = Vector2.MoveTowards(controller.transform.position, patrolPoints[1].position, controller.speed * Time.deltaTime);
            if (Vector2.Distance(controller.transform.position, patrolPoints[1].position) < .2f)
            {
                Flip();
                patrolDestination = 0;
            }
        }
        return this;
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
