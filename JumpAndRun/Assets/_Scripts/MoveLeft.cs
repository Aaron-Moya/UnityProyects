using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindWithTag("Player")
            .GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!_playerController.GameOver)
        {
            this.transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
    }
}
