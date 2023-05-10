using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLifeUp : PowerUp
{
    private float _latestLife;
    private float _damagedLife;

    protected override void applyPowerUp<T>(T entity)
    {
        LifeEntities lifeEntity = entity as LifeEntities;
        _latestLife = lifeEntity.Life;
        lifeEntity.SetLife(1000);
      
    }

    protected override void stopPowerUp<T>(T entity)
    {
        LifeEntities lifeEntity = entity as LifeEntities;
        lifeEntity.SetLife(_latestLife);

    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<LifeEntities>(out LifeEntities entity))
        {
            Debug.Log("On trigger entered");
            StartPowerUp<LifeEntities>(_duration, entity);
        }
    }
}
