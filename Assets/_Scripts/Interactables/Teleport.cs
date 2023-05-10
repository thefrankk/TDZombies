using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractableReceiver
{
    [SerializeField] private int _id;
    public int Id { get => _id; }

    private Transform _objToTeleport;

    private Transform _target;

    private void Awake()
    {
        FindInteractableSender();
    }

    public void DoAction()
    {
        if (_objToTeleport == null)
            return;


        _objToTeleport.transform.position = _target.transform.position;
    }

    public void FindInteractableSender()
    {
        IInteractableObject interactableObject = FindObjectsOfType<MonoBehaviour>().GetInteractableObject(Id);
        interactableObject.InjectDependencies(this);
        _target = interactableObject.GetObjectTransform();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Transform>(out Transform obj))
        {
            _objToTeleport = obj;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _objToTeleport = null;
    }
}
