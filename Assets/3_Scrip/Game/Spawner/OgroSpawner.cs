using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OgroSpawner : Spawner
{
    private float _delayBetweenEnemies;
    [SerializeField] private int _enemyCount;
    private int _maxEnemyCount = 2; // Número máximo de enemigos permitidos
    private int _minEnemyCount = 1; // Número mínimo de enemigos permitidos

    private IEnumerator coroutine;

    public event Action OnEnemiesCleared;

    public int EnemyCount
    {
        get => _enemyCount;
        private set
        {
            _enemyCount = value;
            if (_enemyCount <= 0) OnEnemiesCleared?.Invoke();
        }
    }

    protected override void Spawn()
    {
        if (!IsActive || _enemyCount >= _maxEnemyCount) return;

        Transform enemy = Instantiate(objRef, new Vector3(this.transform.position.x + 0.5f,
            this.transform.position.y,
            this.transform.position.z), objRef.rotation, this.transform);

        Zombie zombie = enemy.GetComponent<Zombie>();

        _enemyCount++;

        zombie.OnEnemyDestroyed += () => EnemyCount--;

        if (_enemyCount >= _maxEnemyCount)
        {
            StopSpawner();
        }
    }

    public override void StartSpawner()
    {
        _isActive = true;
        coroutine = SpawnTimer();
        StartCoroutine(coroutine);
    }

    public override void StopSpawner()
    {
        StopCoroutine(coroutine);

        _isActive = false;
    }

    private IEnumerator SpawnTimer()
    {
        Spawn();
        yield return new WaitForSeconds(_delayBetweenEnemies);
        coroutine = SpawnTimer();
        StartCoroutine(coroutine);
    }

    public void SetDelayBetweenEnemies(float delay)
    {
        _delayBetweenEnemies = delay;
    }

}


