using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MoneyManager 
{
    public static int Money { get; private set; }

    public static void AddMoney(int amount)
    {
        Money += amount;
    }

    public static void RemoveMoney(int amount)
    {
        Money -= amount;
    }


    public static void TryToBuyItem(int amount, Action callback)
    {
        if(amount >= Money)
        {
            callback?.Invoke();
            RemoveMoney(amount);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
