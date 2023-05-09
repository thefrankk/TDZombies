using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform objRef;
    [SerializeField] protected bool _isActive;
    public bool IsActive => _isActive;

    protected abstract void Spawn();

    public abstract void StartSpawner();
    public abstract void StopSpawner();

}
