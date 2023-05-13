using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen_Turret : Turret_GRAL
{

    // Establecemos el tiempo de congelaci�n en segundos.
    public float frozenTime = 3.0f;

    // Creamos una variable para guardar la referencia al enemigo congelado.
    private Zombie frozenEnemy;

    // Este m�todo se ejecuta cuando un objeto entra en el �rea de la torreta.
    void OnTriggerStay(Collider other)
    {
        // Comprobamos si el objeto es un enemigo.
        Zombie enemy = other.GetComponent<Zombie>();

        // Si es un enemigo y no est� congelado, lo congelamos.
        if (enemy != null && frozenEnemy == null)
        {
            // Guardamos la referencia al enemigo congelado.
            frozenEnemy = enemy;

            // Llamamos al m�todo Congelar del enemigo, pas�ndole el tiempo de congelaci�n.
            frozenEnemy.Frozen(frozenTime);
        }
    }

}
