using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_GRAL : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 1f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioClip shootNormalSound;
    private AudioSource audioSource;

    public LayerMask obstacleMask;
    public GameObject particulas;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 2.0f, 0.3f); 
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            Vector3 dirToEnemy = enemy.transform.position - transform.position;
            float distanceToEnemy = dirToEnemy.magnitude;

            if (distanceToEnemy < shortestDistance)
            {
                if (!Physics.Raycast(transform.position, dirToEnemy, distanceToEnemy, obstacleMask))
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
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
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        if (shootNormalSound != null)
        {
            audioSource.PlayOneShot(shootNormalSound);
        }
    }

    void Shoot()
    {
        GameObject bulletBoom = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletBoom.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }

        Instantiate(particulas, firePoint.position, Quaternion.identity);

        if (shootNormalSound != null)
        {
            audioSource.PlayOneShot(shootNormalSound);
        }
    }

   
}

