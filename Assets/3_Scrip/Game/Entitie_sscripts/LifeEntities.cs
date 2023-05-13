using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEntities : MonoBehaviour
{   
    protected float _life;
    public float damage;
    public float speed;

    public float Life => _life;

    public void ReceiveDamage(float damageTaken)
    {
        _life -= damageTaken;
        if (_life <= 0f)
        {
            Die();
        }
    }

    public virtual void SetLife(float life)
    {
        _life = life;
    }
    protected virtual void Die()
    {
        // Agregar animación de muerte pendiente
        Destroy(gameObject);
    }
}
