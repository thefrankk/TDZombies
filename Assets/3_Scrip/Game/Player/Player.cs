using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 movemente;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movemente = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        //rb.MovePosition(transform.position + movemente * speed * Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(movemente);
    }
}


