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



        //Shooting
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
