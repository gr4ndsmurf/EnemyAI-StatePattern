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

    [SerializeField] private int POOL_SIZE = 10;
    public GameObject bulletPrefab;
    public Transform firePointTransform;
    public float bulletSpeed = 15f;
    public float shootingTime = 0.5f;
    public float shootingDelay = 0.5f;

    public Queue<GameObject> bulletPool;

    public Transform armPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Object Pool
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public void HandleShooting()
    {
        GameObject bullet = GetBulletFromPool();

        Vector3 shootDirection = (target.position - transform.position).normalized;
        if (bullet != null)
        {
            bullet.transform.position = firePointTransform.position;
            bullet.SetActive(true);

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = shootDirection * bulletSpeed;

            StartCoroutine(DisableBulletAfterDelay(bullet, 2f));
        }
    }

    private IEnumerator DisableBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnBulletToPool(bullet);
    }

    private GameObject GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }

        return null;
    }

    private void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
