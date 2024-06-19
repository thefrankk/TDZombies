using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestination : MonoBehaviour
{

    public static Action OnEndDestinationReached;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            Debug.Log("Destroying zombie");
            Destroy(zombie.gameObject);
            OnEndDestinationReached?.Invoke();
        }
    }
}
