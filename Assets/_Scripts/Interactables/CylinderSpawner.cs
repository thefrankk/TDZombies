using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CylinderSpawner : MonoBehaviour, IInteractableReceiver
{
    [SerializeField] private Transform _cylinder;
    [SerializeField] private int _id;

    public int Id { get => _id; }

    private void Awake()
    {
        FindInteractableSender();
    }
    public void DoAction()
    {
        Transform newCylinder = Instantiate(_cylinder, new Vector3(this.transform.position.x + 0.5f,
                                                                   this.transform.position.y,
                                                                   this.transform.position.z), _cylinder.rotation, this.transform);


        Destroy(newCylinder.gameObject, 5f);
    }

    public void FindInteractableSender()
    {
        IInteractableObject interactableObject = FindObjectsOfType<MonoBehaviour>().GetInteractableObject(Id);
        interactableObject.InjectDependencies(this);
    }

   
}
