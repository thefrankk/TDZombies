using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBullet : Bullets
{
    private Transform _target;
    private bool _canAttack;

    private void Awake()
    {
        _speed = 20f;
    }

    private void Update()
    {
        if (_canAttack && _target != null)
        {
            Vector3 dir = _target.position - transform.position;
            float distanceThisFrame = _speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget(_target);
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Seek(Transform target)
    {
        _target = _target;

        _canAttack = target != null ? true : false;
    }
    
    
    public override void HitTarget<T>(T target)
    {
        if (target.TryGetComponent<LifeEntities>(out LifeEntities entity))
        {
            entity.ReceiveDamage(_damage);
        }
        
        base.HitTarget(target);
    }
    
    
}
