using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shooter : LifeEntities
{
    private Transform playerPosition;
    public GameObject axePrefab;
    public Transform axeSpawnPoint;
    public float shootInterval = 3f;
    public float speedProj = 10f;
  
    private NavMeshAgent navMeshAgent;
    private float shootTimer = 0f;

    void Start()
    {
        playerPosition = FindObjectOfType<Player>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("ShootPlayer", shootInterval, shootInterval);
    }

    void Update()
    {
        if (playerPosition != null)
        {
            navMeshAgent.SetDestination(playerPosition.position);
        }

       
    }

    void ShootPlayer()
    {
        Vector3 directionToPlayer = (playerPosition.position - axeSpawnPoint.position).normalized;
        
        GameObject newAxe = Instantiate(axePrefab, axeSpawnPoint.position, axeSpawnPoint.rotation);
        Rigidbody axeRigidbody = newAxe.GetComponent<Rigidbody>();
        axeRigidbody.velocity = axeSpawnPoint.forward * speedProj;
       
    }
}

