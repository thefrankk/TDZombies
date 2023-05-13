using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableEntity
{
    public float speed;
    private Rigidbody rb;
    private Vector3 movement;

    public GameObject bombPrefab;
    private float detonationTime = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _speedMovement = 5f;

    }

    private void Update()
    {
       
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        transform.position += transform.right * movement.x * _speedMovement * Time.deltaTime; 
        transform.position += transform.forward * movement.z * _speedMovement * Time.deltaTime; 
    }

    private void FixedUpdate()
    {
       // MoveEntity();
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
}


