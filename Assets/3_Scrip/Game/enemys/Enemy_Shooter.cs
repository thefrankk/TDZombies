using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Shooter : LifeEntities
{
   
        public Transform playerPosition;
        public GameObject axePrefab;
        public Transform axeSpawnPoint;
        public float shootInterval = 3f;
        public float speedProj = 10f;
        public Animator anim;

        private NavMeshAgent navMeshAgent;
        private float shootTimer = 0f;

        private const float shootingDistance = 1.5f;

        private bool isWalking = false;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            InvokeRepeating("ShootPlayer", shootInterval, shootInterval);
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);

            if (distanceToPlayer <= shootingDistance)
            {
                // Disparar al jugador
                anim.SetTrigger("ZOMBIE_ATTACK");
                navMeshAgent.isStopped = true;
            }
            else
            {
                // Caminar hacia el jugador
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(playerPosition.position);
                anim.SetTrigger("Z_WALK");
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

