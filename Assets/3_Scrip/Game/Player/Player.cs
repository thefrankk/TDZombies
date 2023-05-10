using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableEntity
{
    public float speed;
    private Rigidbody rb;
    private Vector3 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _speedMovement = 5f;

    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MoveEntity();
    }

   
    protected override void MoveEntity()
    {
        rb.MovePosition(transform.position + movement * _speedMovement * Time.deltaTime);
    }
}


