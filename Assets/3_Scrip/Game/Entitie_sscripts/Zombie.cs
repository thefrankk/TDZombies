using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MovableEntity
{
    public float life;
    public float speed;
    public float damage;
    private GameObject _aim;
    public NavMeshAgent navMeshAgent;
    private float timeFrozen = 0f;

    public Action OnEnemyDestroyed;
    private MovableEntity _movableEntityImplementation;

    void Start()
    {
        _speedMovement = 3.5f;
        _aim = FindObjectOfType<EndDestination>().gameObject;
        /*  // Seleccionar un Objetivo al azar
          int randomaim = Random.Range(0, 3);

          switch (randomaim)
          {
              case 0: // Mover hacia el jugador
                  aim = GameObject.FindGameObjectWithTag("Player");
                  break;
              case 1: // Mover hacia la torreta
                  aim = GameObject.FindGameObjectWithTag("Torreta");
                  break;
              case 2: // Mover hacia la planta
                  aim = GameObject.FindGameObjectWithTag("Plant");
                  break;
          }*/

        MoveEntity();
    }

    #region//Metodo de congelado y descongelado
    public void Frozen(float time)
    {
        // Llamamos al método Descongelar utilizando una corrutina para esperar el tiempo de congelación.
        StartCoroutine(UnFrozen(time));

        // Desactivamos la navegación del enemigo.
        navMeshAgent.enabled = false;
    }


    // Este método descongela al zombie y activa su navegación de nuevo.
    private IEnumerator UnFrozen(float time )
    {
        // Esperamos el tiempo de congelación.
        yield return new WaitForSeconds(time);

        // Activamos la navegación del zombie.
        navMeshAgent.enabled = true;
    }

    private void Update()
    {
        // Actualizamos el contador de tiempo congelado si es que el zombie está congelado.
        if (timeFrozen > 0f)
        {
            timeFrozen -= Time.deltaTime;
            if (timeFrozen <= 0f)
            {
                // Llamamos al método UnFrozen utilizando una corrutina para esperar el tiempo de congelación.
                StartCoroutine(UnFrozen(3f));
            }
        }

        //Mover el zommbie hacia el objetivo
        if (_aim != null)
        {
       //     transform.position = Vector3.MoveTowards(transform.position, _aim.transform.position, speed * Time.deltaTime);
        }
    }

    public bool IsFrozen()
    {
        return (timeFrozen > 0f);
    }

    #endregion

  /* GENERAR DAÑO A LA TORRETA O PERSONA   
  
    public void InflictDamage(GameObject entity)
    {
        // Obtener el componente Turret_GRAL o Plant de la entidad
        Turret_GRAL turret = entity.GetComponent<Turret_GRAL>();
        Plant plant = entity.GetComponent<Plant>();
        Player human = entity.GetComponent<Player>();

        // Si la entidad tiene componente Turret_GRAL, le restamos vida
        if (turret != null)
        {
            turret.ReceiveDamage(damage);
        }

        // Si la entidad tiene componente Plant, le restamos vida
        if (plant != null)
        {
            plant.ReceiveDamage(damage);
        }

        // Si la entidad tiene componente PLayer, le restamos vida
        if (human != null)
        {
            human.ReceiveDamage(damage);
        }
    }*/
    public void ReceiveDamage(float damageTaken)
    {
        life -= damageTaken;
        if (life <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Agregar animación de muerte pendiente
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("EnemyDestroyed");
        OnEnemyDestroyed?.Invoke();
        
    }

    public override void SetSpeedMovement(float speed)
    {
        base.SetSpeedMovement(speed);
        MoveEntity();
    }
    
    protected override void MoveEntity()
    {
        navMeshAgent.destination = _aim.transform.position;
        navMeshAgent.speed = _speedMovement;

    }
}
