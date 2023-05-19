using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    private float _dirX, _dirY;

    private float _xSpeed = 2, _ySpeed = 1;
    [SerializeField] private float _minRot, _maxRot;
    private float _xRot, _yRot;


   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) return;
       
        // Get the input from the mouse or other input device
        _dirX = Input.GetAxis("Mouse X");
        _dirY = Input.GetAxis("Mouse Y");

        float targetYRot = _player.rotation.eulerAngles.y + _dirX * _xSpeed;

        _player.Rotate(Vector3.up * _dirX * _xSpeed);
        
        _xRot -= _dirY * _xSpeed;
        _xRot = Mathf.Clamp(_xRot, _minRot, _maxRot);

        Vector3 targetPos =  new Vector3(_xRot, 0, 0);
        
        //transform.localEulerAngles = targetPos;



    }

    
    
    
    
}
