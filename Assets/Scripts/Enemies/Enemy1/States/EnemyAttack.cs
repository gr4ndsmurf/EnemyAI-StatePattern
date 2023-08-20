using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : EnemyState
{
    [SerializeField] private float shootingRange = 7f;
    [SerializeField] private Transform movebackPoint;

    private bool shootingDelayed;
    public override EnemyState State(EnemyController controller)
    {
        if (Vector2.Distance(controller.transform.position, controller.target.position) > shootingRange)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            return controller.chase;
        }

        //Moving Back
        if (Vector2.Distance(controller.transform.position, controller.target.position) < 3f)
        {
            controller.aiDestinationSetter.target = movebackPoint;
            controller.aiPath.maxSpeed = controller.speed * 8f;
        }
        else
        {
            controller.aiDestinationSetter.target = controller.target;
            controller.aiPath.maxSpeed = controller.speed * 2f;
        }

        //Flip
        if (controller.aiPath.desiredVelocity.x >= 0.01f)
        {
            controller.transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
        }
        else if (controller.aiPath.desiredVelocity.x <= -0.01f)
        {
            controller.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        //Look at target
        Vector2 direction = new Vector2(controller.target.transform.position.x - controller.transform.position.x, controller.target.transform.position.y - controller.transform.position.y);
        controller.transform.up = Vector3.Lerp(controller.transform.up, direction, controller.damping);

        //Attack
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
