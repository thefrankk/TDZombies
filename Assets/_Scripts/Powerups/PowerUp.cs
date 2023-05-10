using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public abstract class PowerUp : MonoBehaviour 
{
    protected float _duration = 5;


    public virtual void StartPowerUp<T>(float duration, T entity)
    {

        startTimer(duration, () =>
        {
            stopPowerUp(entity);
        });

        applyPowerUp<T>(entity);
    }

    protected abstract void applyPowerUp<T>(T entity);
    private async void startTimer(float duration, Action callback)
    {
        await Task.Delay(Mathf.CeilToInt(duration * 1000));
        callback?.Invoke();
    }

    protected abstract void stopPowerUp<T>(T entity);


    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("On trigger entered");
    //
    //   if(other.TryGetComponent<Player>(out Player entity))
    //     {
    //         StartPowerUp(_duration, entity);
    //     }
    // }

    protected abstract void OnTriggerEnter(Collider other);



}
