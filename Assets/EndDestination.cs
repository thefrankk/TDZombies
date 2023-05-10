using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestination : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            Destroy(zombie.gameObject);
        }
    }
}
