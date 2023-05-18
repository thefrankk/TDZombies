using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBullet : Bullets
{
    private Rigidbody _rb;

    private Vector3 _dir;

    public float speed;
    public ForceMode forceMode;
    
    
    private void Awake()
    {
        _speed = 33f;
        _damage = 10f;
        _rb = GetComponent<Rigidbody>();
    }

    public void ApplyForce(Vector3 dir)
    {
        _dir = dir;
        _rb.AddForce(_dir.normalized * _speed, ForceMode.Impulse);
        
    }

    private void FixedUpdate()
    {
        ApplyForce(_dir);
    }

    public override void HitTarget<T>(T target)
    {
        if (target.TryGetComponent<LifeEntities>(out LifeEntities entity))
        {
            Debug.Log("DAMAGED " + entity.Life);
            //entity.ReceiveDamage(_damage);

            StartCoroutine(makeDamage(entity));
        }
        
        //base.HitTarget(target);
    }

    IEnumerator makeDamage(LifeEntities entity)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("CURRENT DAMAGE " + entity.Life);
        if (entity != null)
        {
            entity?.ReceiveDamage(_damage);
            Debug.Log("Damaged maded " + entity?.Life);
            
        }

    }
}
