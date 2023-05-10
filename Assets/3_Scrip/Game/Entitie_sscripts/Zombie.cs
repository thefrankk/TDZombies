using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : LifeEntities
{
    public GameObject aim;
    public NavMeshAgent navMeshAgent;
    private float timeFrozen = 0f;

    void Start()
    {
        navMeshAgent.destination = aim.transform.position;
    }

    public void Frozen(float time)
    {
        StartCoroutine(UnFrozen(time));
        navMeshAgent.enabled = false;
    }

    private IEnumerator UnFrozen(float time)
    {
        yield return new WaitForSeconds(time);
        navMeshAgent.enabled = true;
    }

    private void Update()
    {
        if (timeFrozen > 0f)
        {
            timeFrozen -= Time.deltaTime;
            if (timeFrozen <= 0f)
            {
                StartCoroutine(UnFrozen(3f));
            }
        }

        if (aim != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, speed * Time.deltaTime);
        }
    }

    public bool IsFrozen()
    {
        return (timeFrozen > 0f);
    }

    public void ApplyFreezeEffect(float freezeTime)
    {
        Frozen(freezeTime); // Congelar al Zombie durante el tiempo especificado
    }

    // Opcional: Si se deseas mantener la función InflictDamage, puedes modificarla para aplicar el efecto de congelación en lugar de dañar al objetivo.
    public void InflictDamage(GameObject entity, float freezeTime)
    {
        Zombie zombie = entity.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.ApplyFreezeEffect(freezeTime);
        }
    }
}

