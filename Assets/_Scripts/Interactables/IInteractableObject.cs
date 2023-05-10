using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObject 
{
    public int Id { get; }
    public float DelayToInteract { get; }
    public float CurrentTime { get; set; }
    public bool CanInteract{ get; set; }
    public void InjectDependencies(IInteractableReceiver interactableReceiver);
    public void Interact();

    public Transform GetObjectTransform();
}
