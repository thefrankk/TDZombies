using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderSpawner : Spawner<Transform>, IInteractableReceiver
{
    [SerializeField] private int _id;

    public int Id { get => _id; }

    private void Awake()
    {
        FindInteractableSender();
    }

    protected override void Spawn()
    {
        
        var newCylinder = Instantiate(_objToSpawn, new Vector3(this.transform.position.x + 0.5f,
                                                                                       this.transform.position.y,
                                                                                       this.transform.position.z), _objToSpawn.rotation, this.transform);
        
        Destroy(newCylinder.gameObject, 5f);

    }

    public override void StartSpawner()
    {
        _isActive = true;
        Spawn();
    }

    public override void StopSpawner()
    {
        _isActive = false;
    }

    public void DoAction()
    {
        Spawn();
    }

    public void FindInteractableSender()
    {
       // IInteractableObject interactableObject = FindObjectsOfType<MonoBehaviour>().GetInteractableObject(Id);
        InteractableObject interactableObject = GetComponentInParent<InteractableObject>();
        interactableObject.InjectDependencies(this);
    }

   
}
