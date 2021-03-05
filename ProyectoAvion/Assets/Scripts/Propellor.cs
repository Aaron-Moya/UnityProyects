using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propellor : MonoBehaviour
{
    [Range(-1000,1000), SerializeField, Tooltip("Rotación del hélice")]
    private float rotateSpeed;
    

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.back * (Time.deltaTime * rotateSpeed));
    }
}
