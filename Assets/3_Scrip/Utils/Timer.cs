using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class Timer  
{
    private static Tween currentTimer;

    public static Tween CreateTimer(float timer, Action callback)
    {
       
        currentTimer = DOVirtual.Float(timer, 0, timer, (x) => { })
            .SetEase(Ease.Linear); 
        
        currentTimer.onComplete += () => callback?.Invoke();

        return currentTimer;
    }

    public static void StopTimer(Tween _tween)
    {
        currentTimer.Kill();
    }
}