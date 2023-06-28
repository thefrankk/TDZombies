using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractableObject
{
    [SerializeField] private float _delay;

    private MovableEntity _movableEntity;
   
    public float DelayToInteract => _delay;

    public float CurrentTime { get; set; }

    private int _currentTime;


    private void Start()
    {
        CanInteract = true;
    }

    public Transform GetObjectTransform()
    {
        return this.transform;
    }
    
    private void Update()
    {
        if (_movableEntity == null)
            return;

        if (Input.GetKeyUp(KeyCode.E) && CanInteract)
        {
            Interact();
            CurrentTime = DelayToInteract;
        }

        if (!CanInteract)
        {
            CurrentTime -= Time.deltaTime;

            if (CurrentTime < 0)
            {
                CanInteract = true;
                CurrentTime = DelayToInteract;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovableEntity>(out MovableEntity obj))
        {
            _movableEntity = obj;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _movableEntity = null;
    }


}