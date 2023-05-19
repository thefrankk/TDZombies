using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LifeEntities : MonoBehaviour
{   
    protected float _life;
    public float damage;
    public float speed;
    public Animator anim;

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

        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("DEATH");
        }
        Destroy(gameObject);

        // Agregar animación de muerte pendiente
       Destroy(this.gameObject);

       

    }
}
