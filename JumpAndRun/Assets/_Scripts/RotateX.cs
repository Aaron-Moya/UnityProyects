using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{
    public float rotateSpeed = 25f;
    public float moveSpeed = 10f;
    
    void Update()
    {
        transform.localPosition += Vector3.left * (moveSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
    }
}
