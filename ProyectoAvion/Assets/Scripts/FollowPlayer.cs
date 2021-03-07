﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 4, -5);
    
    void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}