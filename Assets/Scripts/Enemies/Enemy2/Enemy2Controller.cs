using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2Controller : MonoBehaviour
{
    [Header("States")]
    public Enemy2Chase chase;
    public Enemy2Attack attack;

    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    [Header("WeaponSystem")]
    public float damping = 0.01f;
    public GameObject bullet;
    public Transform gunPoint;

    public Path path;
    public int currentWaypoint = 0;
    public RaycastHit2D isGrounded;
    public Seeker seeker;
    public Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
