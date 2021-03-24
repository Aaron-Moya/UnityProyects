using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    
    private float repeatWidth;
    void Start()
    {
        startPos = this.transform.position;
        
        // Le añadimos un BoxCollider al background para así detectar su tamaño en x, y dividirlo entre 2.
        // De esta forma guardamos en una variable cada cuanto hay que volver a la posición original
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (startPos.x - transform.position.x > repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
