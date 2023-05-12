using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Shooter :LifeEntities
{
    public GameObject projectile;
    public float speedProj = 10f;
    public Transform spawnProjPoint;
    private Transform playerPosition;
    public NavMeshAgent navMeshAgent;


    void Start()
    {
        playerPosition = FindObjectOfType<Player>().transform;

        Invoke("ShootPlayer", 3);
    
    }


    void Update()
    {
        
    }

    void ShootPlayer()
    {
        Vector3 playerdirection = playerPosition.position - transform.position;
        GameObject newProjectile;

        newProjectile = Instantiate(projectile, spawnProjPoint.position, spawnProjPoint.rotation);

        newProjectile.GetComponent<Rigidbody>().AddForce(playerdirection* speedProj ,ForceMode.Force);

        Invoke("ShootPlayer", 3);
    }
}
