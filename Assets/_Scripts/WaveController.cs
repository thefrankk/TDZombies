using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using _Scripts.Spawners;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using TMPro;

public class WaveController : MonoBehaviour
{

    private const float MaxSecondsSpawning = 50;
    private const float MinDelayBetweenEnemies = 0.5f;
    [SerializeField] private EnemySpawner _enemySpawner;
    private float _secondsSpawning = 3;
    private float _delayBetweenEnemies = 1.5f;

    [SerializeField] private TextMeshProUGUI _currentWave;
    private readonly float _secondsForWaitingNextRound = 10;
    public int CurrentWave { get; private set; }

    
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private CancellationToken _cancellationToken;

    
    private void Awake()
    {
        
        StartWave();
        //_enemySpawner.OnEnemiesCleared += configNextWave;
        
        EventHandler.Subscribe(EventHandler.eventName.WAVECLEARED, configNextWave);
        _cancellationToken = _cancellationTokenSource.Token;

    }

    private void Start()
    {
        MoneyManager.AddMoney(400);
    }

    public async void StartWave()
    {
        _enemySpawner.SetDelayBetweenEnemies(_delayBetweenEnemies);
        _enemySpawner.StartSpawner();
        
        _currentWave.text = $"WAVE {CurrentWave}";

        Debug.Log("Enemy Spawner Started");
        await Task.Delay(Mathf.CeilToInt((_secondsSpawning) * 1000), _cancellationToken);
        if (!Application.isPlaying)
        {
            _cancellationTokenSource.Cancel();
            return;
        }
        
        EndWave();
        Debug.Log("Enemy Spawner Ended");

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void EndWave()
    {
        _enemySpawner.StopSpawner();
    }

    private void configNextWave()
    {
        _secondsSpawning = Mathf.Clamp((_secondsSpawning + 1 ), 0, MaxSecondsSpawning);
        _delayBetweenEnemies = Mathf.Clamp((_delayBetweenEnemies - 0.2f ), MinDelayBetweenEnemies, 100);
        
        _currentWave.text = $"WAVE {CurrentWave}";
        NextWave();
    }
    public async void NextWave()
    {
        
        CurrentWave++;
        await Task.Delay(Mathf.CeilToInt((_secondsForWaitingNextRound) * 1000));
        StartWave();
    }
    
}
