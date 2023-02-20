using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CDreyer.Generics;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Projectile projPref;

    StackPool<Projectile> projsPool;

    void Start()
    {
        projsPool = new(projPref, 20, transform);
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Move(dir);

        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void Shoot()
    {
        // Projectile newProj = Instantiate(projPref, transform.position, projPref.transform.rotation);
        Projectile newProj = projsPool.Get(transform.position, projPref.transform.rotation);
    }
}