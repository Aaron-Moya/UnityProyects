﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private float horizontalInput;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
