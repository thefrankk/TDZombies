using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Armor : Zombie
{

    public float armor;

    void Start()
    {
        // Generar un número aleatorio entre 0 y 100 para la armadura 
        GenerarArmadura(out armor);
    }

    // Método para generar la armadura y asignarla a la variable armor utilizando la palabra clave out.
    private void GenerarArmadura(out float armorValue)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            armorValue = Random.Range(0f, 100f);
        }
        else
        {
            armorValue = 0f;
        }
    }

    public void RecibirDaño(float damage_torreta)
    {
        // Calcular el daño real considerando la armadura
        float acurrate_damage = damage_torreta;

        if (armor > 0)
        {
            acurrate_damage *= (1 - armor / 100);
        }

        life -= acurrate_damage;

        if (life <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}

