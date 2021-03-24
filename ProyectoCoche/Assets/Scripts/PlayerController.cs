using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(-10,20), SerializeField, Tooltip("Velocidad del automóbil")] 
    private float speed = 10f;
    [Range(-256,256), SerializeField, Tooltip("Velocidad del giro")] 
    private float turnSpeed = 40f;

    private float horizontalInput, verticalInput;
    
    void Start()
    {
        Debug.Log("Se ha iniciado el juego!");
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        this.transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput));
        this.transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
    }
}
