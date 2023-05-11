using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SuckerZombie : LifeEntities
{
    public Transform player;
    public float atractionSuckerP = 5f;
    public bool suckerPlayer = false;
    private Transform arm;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        arm = transform.GetChild(0);
        arm.gameObject.SetActive(false);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (suckerPlayer)
        {
            Vector3 direction = player.position - arm.position;
            arm.Translate(direction.normalized * atractionSuckerP * Time.deltaTime);
        }

        if (Vector3.Distance(arm.position, player.position) < 0.5f)
        {
            ReleasePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.enabled = false;
            suckerPlayer = true;
            arm.gameObject.SetActive(true);
        }
    }
    void ReleasePlayer()
    {
        suckerPlayer = false;
        arm.gameObject.SetActive(false);
        navMeshAgent.enabled = true;
    }
}



