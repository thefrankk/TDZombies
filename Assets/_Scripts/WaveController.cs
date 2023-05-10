using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using _Scripts.Spawners;
using UnityEngine;
using System.Threading.Tasks;
public class WaveController : MonoBehaviour
{

    private const float MaxSecondsSpawning = 50;
    private const float MinDelayBetweenEnemies = 0.5f;
    [SerializeField] private EnemySpawner _enemySpawner;
    private float _secondsSpawning = 3;
    private float _delayBetweenEnemies = 1.5f;

    private readonly float _secondsForWaitingNextRound = 20;
    public int CurrentWave { get; private set; }

    private void Awake()
    {
        StartWave();
        _enemySpawner.OnEnemiesCleared += configNextWave;
    }

    public async void StartWave()
    {
        _enemySpawner.SetDelayBetweenEnemies(_delayBetweenEnemies);
        _enemySpawner.StartSpawner();

        await Task.Delay(Mathf.CeilToInt((_secondsSpawning) * 1000));
        EndWave();
    }


    public void EndWave()
    {
        _enemySpawner.StopSpawner();
    }

    private void configNextWave()
    {
        _secondsSpawning = Mathf.Clamp((_secondsSpawning + 1 ), 0, MaxSecondsSpawning);
        _delayBetweenEnemies = Mathf.Clamp((_delayBetweenEnemies - 0.2f ), MinDelayBetweenEnemies, 100);
        NextWave();
    }
    public async void NextWave()
    {
        
        CurrentWave++;
        await Task.Delay(Mathf.CeilToInt((_secondsForWaitingNextRound) * 1000));
        StartWave();
    }
    
}
