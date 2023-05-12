using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shooter : LifeEntities
{
    public GameObject axePrefab;
    public Transform axeSpawnPoint;
    public float shootInterval = 3f;
    public float speedProj = 10f;
    private Transform playerPosition;
    private NavMeshAgent navMeshAgent;
    private float shootTimer = 0f;

    void Start()
    {
        playerPosition = FindObjectOfType<Player>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (playerPosition != null)
        {
            navMeshAgent.SetDestination(playerPosition.position);
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            InvokeRepeating("ShootPlayer", shootInterval, shootInterval);
            shootTimer = 0f;
        }
    }

    void ShootPlayer()
    {
        
        if (Vector3.Distance(transform.position, playerPosition.position) <= navMeshAgent.stoppingDistance)
        {
            GameObject newAxe = Instantiate(axePrefab, axeSpawnPoint.position, axeSpawnPoint.rotation);
            Rigidbody axeRigidbody = newAxe.GetComponent<Rigidbody>();
            axeRigidbody.velocity = axeSpawnPoint.forward * speedProj;
        }
    }
}

