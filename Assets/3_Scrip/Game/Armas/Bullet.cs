using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 20f;

    private bool _canAttack;

    private int _bulletDamage = 25;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Seek(Transform _target)
    {
        target = _target;

        _canAttack = target != null ? true : false;
    }

    void Update()
    {
        if (_canAttack && target != null)
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ApplyForce()
    {
        _rb.AddForce(Vector3.zero * 5, ForceMode.Impulse);
    }
    void HitTarget()
    {
        if(target.TryGetComponent(out LifeEntities entity))
        {
            entity.ReceiveDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}
