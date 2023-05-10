using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Turret_GRAL : MonoBehaviour
{
    public Transform target;
    public float range= 15f;
    public float damage;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;
     


    private void Start()
    {
        InvokeRepeating("Updatetarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearesEnemy = enemy;
            }
        }

        if (nearesEnemy != null && shortestDistance <= range)
        {
            target = nearesEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation =Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCountdown<= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;


            fireCountdown -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        Debug.Log("SHOOT");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}


