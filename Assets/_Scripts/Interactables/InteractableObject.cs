using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private int _id;
    public int Id => _id;
    
    public bool CanInteract { get; set; }
    
    
    protected IInteractableReceiver receiver;

    public void InjectDependencies(IInteractableReceiver interactableReceiver)
    {
        receiver = interactableReceiver;
    }

    protected void Interact()
    {
        receiver.DoAction();
        CanInteract = false;

    }

}
