using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [FormerlySerializedAs("objRef")] [SerializeField] protected T _objToSpawn;
    [SerializeField] protected bool _isActive;
    public bool IsActive => _isActive;

    protected abstract void Spawn();

    public abstract void StartSpawner();
    public abstract void StopSpawner();

}
