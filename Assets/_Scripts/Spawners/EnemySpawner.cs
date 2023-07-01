using System.Collections;
using UnityEngine;
using System;

namespace _Scripts.Spawners
{
    public class EnemySpawner : Spawner<MovableEntity>
    {

        private float _delayBetweenEnemies;
        [SerializeField] private int _enemyCount;

        private IEnumerator coroutine;
        
        private ObjectPooling<Zombie> _zombiePool;
       
        public event Action OnEnemiesCleared;
        public int EnemyCount
        {
            get => _enemyCount;
            private set
            {
                _enemyCount = value;
                if (_enemyCount <= 0) EventHandler.TriggerEvent(EventHandler.eventName.WAVECLEARED);
            }
        }
        

        private void Awake()
        {
            _zombiePool = new ObjectPooling<Zombie>("Zombie Pool", _objToSpawn.GetComponent<Zombie>(), 50);
            EventHandler.Subscribe(EventHandler.eventName.WAVECLEARED, OnEnemiesCleared);

        }
        protected override void Spawn()
        {
            if (!IsActive) return;

          
            
            Zombie enemy = _zombiePool.GetObjectFromPool();
            enemy.Config(new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z));

       
            
            _enemyCount++;

            enemy.OnEnemyDestroyed += () => EnemyCount--;
            
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
        
                    
        
        
        
        

        public void SetDelayBetweenEnemies(float delay) => _delayBetweenEnemies = delay;
    }
}

