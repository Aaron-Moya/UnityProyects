using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 20f;
    
    private float spawnPosZ;

    [SerializeField]
    private float startDelay = 2f;
    [SerializeField]
    private float spawnInterval = 1.5f;

    private void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    

    private void SpawnRandomAnimal()
    {
        //Generar la posición donde aparecerá el siguiente enemigo
        float xRandom = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRandom, 0, spawnPosZ);
            
        //Instanciar enemigos
        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], 
            spawnPos, 
            enemies[animalIndex].transform.rotation);
    }
}
