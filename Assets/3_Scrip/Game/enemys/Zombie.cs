using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MovableEntity
{
    public float life;
    private GameObject _aim;
    public NavMeshAgent navMeshAgent;
    private float timeFrozen = 0f;

    public Action OnEnemyDestroyed;
    private MovableEntity _movableEntityImplementation;

    void Start()
    {
        _life = 125;
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
        // Llamamos al m�todo Descongelar utilizando una corrutina para esperar el tiempo de congelaci�n.
        StartCoroutine(UnFrozen(time));

        // Desactivamos la navegaci�n del enemigo.
        navMeshAgent.enabled = false;
    }


    // Este m�todo descongela al zombie y activa su navegaci�n de nuevo.
    private IEnumerator UnFrozen(float time )
    {
        // Esperamos el tiempo de congelaci�n.
        yield return new WaitForSeconds(time);

        // Activamos la navegaci�n del zombie.
        navMeshAgent.enabled = true;
    }

    private void Update()
    {
        // Actualizamos el contador de tiempo congelado si es que el zombie est� congelado.
        if (timeFrozen > 0f)
        {
            timeFrozen -= Time.deltaTime;
            if (timeFrozen <= 0f)
            {
                // Llamamos al m�todo UnFrozen utilizando una corrutina para esperar el tiempo de congelaci�n.
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

  /* GENERAR DA�O A LA TORRETA O PERSONA   
  
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
        if (navMeshAgent == null) return;
        navMeshAgent.destination = _aim.transform.position;
        navMeshAgent.speed = _speedMovement;

    }
}
