using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [Header("Controller")]
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 3f;

    [Header("States")]
    public EnemyChase chase;
    public EnemyAttack attack;

    [Header("Pathfinding")]
    public Transform target;
    public AIPath aiPath;
    public AIDestinationSetter aiDestinationSetter;

    [Header("WeaponSystem")]
    public float damping = 0.01f;
    public GameObject bullet;
    public Transform gunPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
