using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Node : MonoBehaviour, IInteractableReceiver
{
    [SerializeField] private int _id;

    private Turret_GRAL _currentTurret;
    private void Start()
    {
        FindInteractableSender();
    }

    public int Id => _id;

    

    public void SetCurrentTurret(Turret_GRAL turret)
    {
        _currentTurret = turret;
    }
    public Turret_GRAL GetCurrentTurret() => _currentTurret;
    public void DoAction()
    {
       UITurretsManager.Instance.OpenOrClosePopUp(this);
    }
    public void FindInteractableSender()
    {
        InteractableObject interactableObject = GetComponentInChildren<InteractableObject>();
        interactableObject.InjectDependencies(this);
    }
}
