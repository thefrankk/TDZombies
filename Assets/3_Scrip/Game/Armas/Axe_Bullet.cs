using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Bullet : MonoBehaviour
{
    public float speedAxe = 10f;
    public float rotationSpeed = 50;

    private Rigidbody rb;
    public bool isRotating = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speedAxe;
    }
    void FixedUpdate()
    {
        if (isRotating)
        {

            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isRotating = false;
        rb.velocity = Vector3.zero;

        Destroy(gameObject);
    }
}
