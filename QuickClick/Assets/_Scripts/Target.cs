using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private float minForce = 12.5f, maxForce = 18;
    private float maxTorque = 10;
    private float xRange = 4, ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), 
            ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = FindObjectOfType<GameManager>();
    }

    // Devuelve un Vector3 hacia arriba con una x random y la z = 0
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    // Devuelve un float random para la torsión de un objeto
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Devuelve un Vector3 con la x Random, la y fija  y la z = 0, para spawnear objetos
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(this.gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
            if (this.gameObject.CompareTag("Good"))
            {
                gameManager.GameOver();
            }
        }
    }
}
