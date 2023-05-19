using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MovableEntity, ICameraControllable
{
    private Rigidbody rb;
    private Vector3 movement;
    public Animator anim;
    public GameObject bombPrefab;
    private float detonationTime = 3f;
    
    

    //Camera settings
    private float _distance = 5.0f;
    private float _height = 2.0f;


    public static Player Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _speedMovement = 5f;
        
        CameraController.Instance.SetTarget(this);
       

    }

    private void Update()
    {
        if (CameraController.Instance.Target != this)
            return;
        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        transform.position += transform.right * movement.x * _speedMovement * Time.deltaTime; 
        transform.position += transform.forward * movement.z * _speedMovement * Time.deltaTime;

        if (movement.x != 0)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }



    }

   
    protected override void MoveEntity()
    {
        rb.MovePosition(transform.position + movement * _speedMovement * Time.deltaTime);

    }

    void InstanciarBomba()
    {
        Invoke("DetonarBomba", detonationTime);
    }

    void DetonarBomba()
    {
        GameObject bomba = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Bomba bombaScript = bomba.GetComponent<Bomba>();
        if (bombaScript != null)
        {
            Invoke("Detonar", detonationTime);
        }
    }

    public void MoveCamera(CameraController cameraController, ref InputMovement inputMovement)
    {
        Vector3 targetPosition = this.transform.position - (this.transform.rotation * Vector3.forward * _distance) + (Vector3.up * _height);
        cameraController.transform.position = Vector3.Slerp(cameraController.transform.position, targetPosition, Time.deltaTime * 15f);

        // Make the camera look at the target.
        cameraController.transform.LookAt(this.transform);
        
        this.transform.Rotate(Vector3.up * inputMovement.DirX * 2);

    }
}


