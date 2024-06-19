using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    private float _xSpeed = 2;


    private float _distance = 5.0f;
    private float _height = 2.0f;
    private float _rotationSpeed = 3.0f;

    private float _xAngle = 0.0f;
    private float _yAngle = 0.0f;
    private float _dirX, _dirY;


    public ICameraControllable Target => _cameraControllable;
   
    public static CameraController Instance; 
    
    ICameraControllable _cameraControllable;

    private InputMovement _inputMovement;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
            Destroy(this);

        _inputMovement = new InputMovement(0, 0, 0, 0);
        Vector3 angles = transform.eulerAngles;
        _xAngle = angles.y;
    }

    // Update is called once per frame
    void Update()
    {
        _inputMovement.XAngle += Input.GetAxis("Mouse X") * _rotationSpeed;
        _inputMovement.YAngle -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        
        _inputMovement.DirX = Input.GetAxis("Mouse X");
        
        if (Input.GetMouseButton(1)) return;

        _cameraControllable.MoveCamera(this, ref _inputMovement);
     
       
    }

    

    public void SetTarget(ICameraControllable target) => _cameraControllable = target;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("On wall");

    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Inside the wall");

    }
}

public struct InputMovement
{
    public float XAngle, YAngle;
    public float DirX, DirY;
    
    public InputMovement(float xAngle, float yAngle, float dirX, float dirY)
    {
        XAngle = xAngle;
        YAngle = yAngle;
        DirX = dirX;
        DirY = dirY;
    }
}
