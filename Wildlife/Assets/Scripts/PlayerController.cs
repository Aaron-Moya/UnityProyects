using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;

    public float xRange = 15f; //Rango máximo del eje x

    public GameObject projectilePrefab;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.right * (Time.deltaTime * speed * horizontalInput));

        //Si el personaje se sale de la pantalla se detiene
        if (this.transform.position.x < -xRange)
        {
            this.transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (this.transform.position.x > xRange)
        {
            this.transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        //Acciones del personaje
        if (Input.GetKey(KeyCode.Space)) //Lanzar proyectiles
        {
            Instantiate(projectilePrefab, this.transform.position, projectilePrefab.transform.rotation);
            
        }
        
    }
}
