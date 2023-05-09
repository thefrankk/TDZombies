using System.Collections;
using UnityEngine;

namespace _Scripts.Spawners
{
    public class EnemySpawner : Spawner, IInteractableReceiver
    {

        [SerializeField] private float _delay;
        [SerializeField] private int _id;

        public int Id => _id;


        private void Awake()
        {
            //FindInteractableSender();
            StartSpawner();
        }
        protected override void Spawn()
        {
            if (!IsActive) return;
            
            var enemy = Instantiate(objRef, new Vector3(this.transform.position.x + 0.5f,
                this.transform.position.y,
                this.transform.position.z), objRef.rotation, this.transform);
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
            yield return new WaitForSeconds(_delay);
            StartCoroutine(SpawnTimer());

        }
        public void DoAction()
        {
            StartSpawner();
        }

        public void FindInteractableSender()
        {
            IInteractableObject interactableObject = FindObjectsOfType<MonoBehaviour>().GetInteractableObject(Id);
            interactableObject.InjectDependencies(this);
        }
    }
}

