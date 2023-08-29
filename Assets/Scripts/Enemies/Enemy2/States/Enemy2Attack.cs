using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : Enemy2State
{
    [SerializeField] private float shootingRange = 7f;
    [SerializeField] private Transform movebackPoint;
    public override Enemy2State State(Enemy2Controller controller)
    {
        if (Vector2.Distance(controller.transform.position, controller.target.position) > shootingRange)
        {
            controller.animator.SetBool("Chase", true);
            controller.animator.SetBool("Attack", false);
            controller.CancelInvoke("HandleShooting");
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


        return this;
    }

    private void WeaponAiming(Enemy2Controller controller)
    {
        //Weapon Aim
        Vector2 direction = new Vector2(controller.target.transform.position.x - controller.armPoint.transform.position.x, controller.target.transform.position.y - controller.armPoint.transform.position.y);
        controller.armPoint.transform.right = Vector3.Lerp(controller.armPoint.transform.right, direction, controller.damping);
        //Flip weapon
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 armPointLocalScale = controller.armPoint.transform.localScale;
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
        controller.armPoint.transform.localScale = armPointLocalScale;
    }
}
