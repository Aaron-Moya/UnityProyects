using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(-20,20), SerializeField, Tooltip("Velocidad del avión")]
    private float speed;
    [Range(-256,256), SerializeField, Tooltip("Velocidad de giro del avión")]
    private float turnSpeed;
    [Range(-256,256), SerializeField, Tooltip("Rotación horizontal del avión")]
    private float rotateSpeed;

    private float horizontalInput;
    private float verticalInput;
    private float rotateInput;
    
    void Update()
    {
        //Aceleración del jugador
        this.transform.Translate(speed * Time.deltaTime * Vector3.forward);
        
        //Movimiento horizotal
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up * (turnSpeed * Time.deltaTime * horizontalInput));
        
        //Movimiento vertical
        verticalInput = Input.GetAxis("Vertical");
        this.transform.Rotate(Vector3.left * (turnSpeed * Time.deltaTime * verticalInput));
        
        //Rotación horizontal
        rotateInput = Input.GetAxis("Rotate");
        this.transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime * rotateInput));
    }
}
