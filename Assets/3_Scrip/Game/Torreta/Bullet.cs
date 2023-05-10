using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 20f;

    private bool _canAttack;

    public void Seek(Transform _target)
    {
        target = _target;

        _canAttack = target != null ? true : false;
    }

    void Update()
    {
        if (_canAttack)
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                //  HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
