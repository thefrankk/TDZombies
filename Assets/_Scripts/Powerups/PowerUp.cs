using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public abstract class PowerUp : MonoBehaviour 
{
    private float _duration = 0;


    public virtual void StartPowerUp(float duration, Player player)
    {

        startTimer(duration, () =>
        {
            stopPowerUp();
        });

        applyPowerUp(player);
    }

    protected abstract void applyPowerUp(Player player);
    private async void startTimer(float duration, Action callback)
    {
        await Task.Delay(Mathf.CeilToInt(duration * 1000));
        callback?.Invoke();
    }

    protected abstract void stopPowerUp();


    private void OnTriggerEnter(Collider other)
    {
      if(other.TryGetComponent<Player>(out Player entity))
        {
            StartPowerUp(_duration, entity);
        }
    }
}
