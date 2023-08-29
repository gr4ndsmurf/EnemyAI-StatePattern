using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : Enemy2State
{
    [SerializeField] private float shootingRange = 7f;
    [SerializeField] private Transform movebackPoint;

    private bool shootingDelayed;
    public override Enemy2State State(Enemy2Controller controller)
    {
        if (Vector2.Distance(controller.transform.position, controller.target.position) > shootingRange)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            return controller.chase;
        }

        //Attack Codes
        if (controller.TargetInDistance() && controller.followEnabled)
        {
            controller.PathFollow();
        }

        if (Vector2.Distance(controller.transform.position,controller.target.position) <= 5f)
        {
            controller.followEnabled = false;
            controller.rb.mass = 50f;
        }
        else
        {
            controller.followEnabled = true;
            controller.rb.mass = 1f;
        }

        WeaponAiming(controller);

        //Shooting
        if (shootingDelayed == false)
        {
            shootingDelayed = true;
            Instantiate(controller.bullet, controller.gunPoint.position, controller.transform.rotation);
            StartCoroutine(shootingCooldown());
        }

        return this;
    }

    private void WeaponAiming(Enemy2Controller controller)
    {
        //Weapon Aim
        Vector2 direction = new Vector2(controller.target.transform.position.x - controller.gunPoint.transform.position.x, controller.target.transform.position.y - controller.gunPoint.transform.position.y);
        controller.gunPoint.transform.right = Vector3.Lerp(controller.gunPoint.transform.right, direction, controller.damping);
        //Flip weapon
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 armPointLocalScale = controller.gunPoint.transform.localScale;
        if (angle > 90 || angle < -90)
        {
            armPointLocalScale.x = -0.8f;
            armPointLocalScale.y = -0.14f;
        }
        else
        {

            armPointLocalScale.x = +0.8f;
            armPointLocalScale.y = +0.14f;
        }
        controller.gunPoint.transform.localScale = armPointLocalScale;
    }

    IEnumerator shootingCooldown()
    {
        yield return new WaitForSeconds(1f);
        shootingDelayed = false;
    }
}
