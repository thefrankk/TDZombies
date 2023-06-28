using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    
    private static Dictionary<eventName, Action> _eventDictionary = new Dictionary<eventName, Action>();


    public enum eventName
    {
        WAVECLEARED,
    }
    //Properties
    public static Dictionary<eventName, Action> EventDictionary => _eventDictionary;
    
    
    public static void Subscribe(eventName eventName, Action callback)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            _eventDictionary[eventName] += callback;
        }
    }
    
    public static void Unsubscribe(eventName eventName, Action callback)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            _eventDictionary[eventName] -= callback;
        }
    }
    
    public static void TriggerEvent(eventName eventName)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            _eventDictionary[eventName]?.Invoke();
        }
    }
    
    public static void RegisterEvent(eventName eventName, Action callback)
    {
        if (!_eventDictionary.ContainsKey(eventName))
        {
            _eventDictionary.Add(eventName, callback);
        }
    }
    
    
    
    
    
    

}