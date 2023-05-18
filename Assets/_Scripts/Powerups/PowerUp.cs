using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;
using System.Threading;
public abstract class PowerUp : MonoBehaviour 
{
    protected float _duration = 5;

    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private CancellationToken _cancellationToken;

    private void Awake()
    {
        _cancellationToken = _cancellationTokenSource.Token;

    }

    public virtual void StartPowerUp<T>(float duration, T entity)
    {

        startTimer(duration, () =>
        {
            if (entity == null) return;
              stopPowerUp(entity);
        });

        applyPowerUp<T>(entity);
    }

    protected abstract void applyPowerUp<T>(T entity);
    private async void startTimer(float duration, Action callback)
    {
        await Task.Delay(Mathf.CeilToInt(duration * 1000));

        if (!Application.isPlaying)
        {
            _cancellationTokenSource.Cancel();
            return;
        }
        
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
