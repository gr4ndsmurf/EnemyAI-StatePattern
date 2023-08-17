using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    [SerializeField] private float bulletSpeed;
    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        bulletRB.velocity = transform.up * bulletSpeed;
        StartCoroutine(BulletRange());
    }

    IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
