using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen_Turret : Turret_GRAL
{

    // Establecemos el tiempo de congelación en segundos.
    public float frozenTime = 3.0f;

    // Creamos una variable para guardar la referencia al enemigo congelado.
    private Zombie frozenEnemy;

    // Este método se ejecuta cuando un objeto entra en el área de la torreta.
    void OnTriggerStay(Collider other)
    {
        // Comprobamos si el objeto es un enemigo.
        Zombie enemy = other.GetComponent<Zombie>();

        // Si es un enemigo y no está congelado, lo congelamos.
        if (enemy != null && frozenEnemy == null)
        {
            // Guardamos la referencia al enemigo congelado.
            frozenEnemy = enemy;

            // Llamamos al método Congelar del enemigo, pasándole el tiempo de congelación.
            frozenEnemy.Frozen(frozenTime);
        }
    }

}
