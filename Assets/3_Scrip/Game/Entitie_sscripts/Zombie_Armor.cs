using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Armor : Zombie
{

        public int vida = 100;
    public float porcentajeProteccion = 0.6f;

    public void RecibirDanio(int cantidadDanio)
    {
        int danioFinal = Mathf.RoundToInt(cantidadDanio * (1f - porcentajeProteccion));
        vida -= danioFinal;

        if (vida <= 0)
        {
            // El enemigo ha sido derrotado
            Destroy(gameObject);
        }
    }
}

