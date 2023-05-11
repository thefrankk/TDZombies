using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : InteractableObject
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovableEntity>(out MovableEntity obj))
        {
            Interact();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Interact();
        CanInteract = true;
    }
}
