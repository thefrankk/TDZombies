using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret_GRAL : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float radius = 10f;
    public float fireDelay = 5f;
    private Transform target;
    
    private void Update()
    {
       /* // Si hay un objetivo actual, lo seguimos con la torreta
        if (target != null)
        {
            // Rotamos la torreta hacia el objetivo
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            // Si el objetivo está fuera del radio, lo perdemos
            if (direction.magnitude > radius)
            {
                target = null;
            }
        }
        // Si no hay un objetivo actual, buscamos uno dentro del radio
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            float closestDistance = Mathf.Infinity;

            foreach (Collider collider in colliders)
            {
                // Si el collider tiene el tag "Enemy", lo consideramos como objetivo
                if (collider.CompareTag("Enemy"))
                {
                    // Calculamos la distancia entre la torreta y el enemigo
                    float distance = (collider.transform.position - transform.position).magnitude;

                    // Si el enemigo está dentro del radio y es el más cercano lo seleccionamos como objetivo
                    if (distance < radius && distance < closestDistance)
                    {
                        closestDistance = distance;
                        target = collider.transform;
                    }
                }
            }
        }*/

        //  tiempo de espera, disparamos 
        if (target != null && Time.time > fireDelay)
        {
            // Creamos una instancia de la flecha en la posición de la torreta
            GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, transform.rotation);

            // Hacemos que la flecha mire hacia el objetivo
            Vector3 direction = target.position - arrowInstance.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            arrowInstance.transform.rotation = rotation;

            // Reseteamos el tiempo de espera
            fireDelay = Time.time + 5f;
        }
    }
}

