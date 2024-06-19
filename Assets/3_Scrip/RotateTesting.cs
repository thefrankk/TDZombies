using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTesting : MonoBehaviour
{
       [SerializeField] private float _rotationSpeed = 1;

    // Update is called once per frame
    
    private Transform _target;
    private Vector3 dir;
    private void Awake()
    {
        _target = FindObjectOfType<Player>().transform;
        
        
    }

    void Update()
    {
        
        Quaternion targetRotation = Quaternion.LookRotation(_target.position - transform.position);
        Vector3 rotation = targetRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(rotation.x, -10f, 10), rotation.y, 0);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
