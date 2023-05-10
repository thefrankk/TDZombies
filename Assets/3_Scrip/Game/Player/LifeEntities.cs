using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntities : MonoBehaviour
{   public float life;
    public float damage;
    public float speed;


    public void ReceiveDamage(float damageTaken)
    {
        life -= damageTaken;
        if (life <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Agregar animación de muerte pendiente
        Destroy(gameObject);
    }
}
