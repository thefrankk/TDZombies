using System.Collections;
using UnityEngine;
using System;


namespace _Scripts.Spawners
{
    public class EnemySpawner : Spawner
    {

        private float _delayBetweenEnemies;
        [SerializeField] private int _enemyCount;

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
            if (!IsActive) return;
            
            Transform enemy = Instantiate(objRef, new Vector3(this.transform.position.x + 0.5f,
                this.transform.position.y,
                this.transform.position.z), objRef.rotation, this.transform);


            Zombie zombie = enemy.GetComponent<Zombie>();
            
            _enemyCount++;

            zombie.OnEnemyDestroyed += () => EnemyCount--;
            
            Debug.Log(_enemyCount);
        }

        public override void StartSpawner()
        {
            _isActive = true;
            StartCoroutine(SpawnTimer());
        }

        public override void StopSpawner()
        {
            StopCoroutine((SpawnTimer()));

            _isActive = false;
        }

     
        private IEnumerator SpawnTimer()
        {
            Spawn();
            yield return new WaitForSeconds(_delayBetweenEnemies);
            StartCoroutine(SpawnTimer());

        }
        
                    
        
        
        
        

        public void SetDelayBetweenEnemies(float delay) => _delayBetweenEnemies = delay;
    }
}

