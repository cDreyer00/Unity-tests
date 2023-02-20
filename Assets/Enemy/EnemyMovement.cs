using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CDreyer.Generics;

public class EnemyMovement : MonoBehaviour, IPoolable<EnemyMovement>
{
    [SerializeField] float baseSpeed;
    [SerializeField] float accel;
    float speed;

    PlayerController player => FindObjectOfType<PlayerController>();
    float dist => Vector3.Distance(player.transform.position, transform.position);

    public GenericPool<EnemyMovement> Pool { get; set; }

    public void OnGet(GenericPool<EnemyMovement> pool)
    {
        Pool = pool;
        speed = baseSpeed;
    }

    public void OnRelease()
    {

    }

    private void Update()
    {
        speed += accel * Time.deltaTime;

        Vector3 dir = player.transform.position - transform.position;
        Move(dir.normalized);

        if (dist < 1)
        {
            HitPlayer();
        }
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void HitPlayer()
    {
        Pool.Release(this);
    }
}