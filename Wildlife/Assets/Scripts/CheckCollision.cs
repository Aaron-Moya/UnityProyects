using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemie"))
        {
            Destroy(this.gameObject); //Destruye el proyectil
            Destroy(other.gameObject); //Destruye el animal
        }
    }
}
