using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedMovement : PowerUp
{
    private float _latestSpeed;
    private void Start()
    {
        _duration = 5;
    }

    protected override void applyPowerUp<T>(T entity)
    {
        MovableEntity movableEntity = entity as MovableEntity;
        _latestSpeed = movableEntity.SpeedMovement;
        movableEntity.SetSpeedMovement(10);
    }

    protected override void stopPowerUp<T>(T entity)
    {
        MovableEntity movableEntity = entity as MovableEntity;
        movableEntity.SetSpeedMovement(_latestSpeed);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovableEntity>(out MovableEntity entity))
        {
            Debug.Log("Start powerup");
            StartPowerUp<MovableEntity>(_duration, entity);
        }
    }
}


