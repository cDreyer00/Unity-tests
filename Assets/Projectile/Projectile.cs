using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CDreyer.Generics;

public class Projectile : MonoBehaviour, IPoolable<Projectile>
{
    float timer;

    public GenericPool<Projectile> Pool { get; set; }

    public void OnGet(GenericPool<Projectile> pool)
    {
        Pool = pool;
        timer = Time.time;
        
    }

    public void OnRelease()
    {
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * 10;

        if (Time.time > timer + 3) Pool.Release(this);
    }
}
