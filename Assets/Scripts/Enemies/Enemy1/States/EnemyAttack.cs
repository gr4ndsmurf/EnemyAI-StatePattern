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

    private bool shootingDelayed;
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
            aiPath.maxSpeed = controller.speed * 8f;
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
        Vector2 direction = new Vector2(target.transform.position.x - controller.transform.position.x, target.transform.position.y - controller.transform.position.y);
        controller.transform.up = Vector3.Lerp(controller.transform.up, direction, controller.damping);
        if (shootingDelayed == false)
        {
            shootingDelayed = true;
            Instantiate(controller.bullet, controller.gunPoint.position, controller.transform.rotation);
            StartCoroutine(shootingCooldown());
        }
        return this;
    }

    IEnumerator shootingCooldown()
    {
        yield return new WaitForSeconds(1f);
        shootingDelayed = false;
    }
}
