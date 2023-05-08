using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractableObject
{
    [SerializeField] private int _id;
    [SerializeField] private float _delay;

    IInteractableReceiver receiver;

    public int Id { get => _id; }

    public float DelayToInteract => _delay;

    public float CurrentTime { get; set; }
    public bool CanInteract { get; set; }

    private int _currentTime;

    public void InjectDependencies(IInteractableReceiver interactableReceiver)
    {
        receiver = interactableReceiver;
    }

    public void Interact()
    {
        receiver.DoAction();
    }





    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanInteract)
        {
            Interact();
            CanInteract = false;
            CurrentTime = DelayToInteract;

        }

        if (!CanInteract)
        {
            CurrentTime -= Time.deltaTime;

            if(CurrentTime < 0)
            {
                CanInteract = true;
                CurrentTime = DelayToInteract;
            }
        }

    }
}
