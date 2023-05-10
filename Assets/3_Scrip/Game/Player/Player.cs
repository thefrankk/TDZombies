using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : LifeEntities
{
    private Rigidbody rb;
    private Vector3 movement;

    public GameObject bombPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            InstanciarBomba();
        }
    }

    private void FixedUpdate()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    void InstanciarBomba()
    {
        GameObject bomba = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Bomba bombaScript = bomba.GetComponent<Bomba>();
        if (bombaScript != null)
        {
            bombaScript.Detonar();
        }
    }
}




