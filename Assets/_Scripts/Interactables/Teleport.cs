using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractableReceiver
{
    [SerializeField] private int _id;
    public int Id { get => _id; }

    private Transform _objToTeleport;

    private Transform _target;

    private void Awake()
    {
        _objToTeleport = FindObjectOfType<Player>().transform;
        FindInteractableSender();
    }

    public void DoAction()
    {
        if (_objToTeleport == null)
            return;

        _objToTeleport.transform.position = this.transform.position;
    }

    public void FindInteractableSender()
    {
        InteractableObject interactableObject = FindObjectsOfType<InteractableObject>().FirstOrDefault(x => x.Id == Id);
                                                                                        
        interactableObject.InjectDependencies(this);
    }

}
