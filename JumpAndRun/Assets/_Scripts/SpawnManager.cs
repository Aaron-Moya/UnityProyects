using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    public float startDelay = 1f;
    public float repeatRate = 3f;

    private PlayerController _playerController;
    
    void Start()
    {
        spawnPos = this.transform.position;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            repeatRate = Random.Range(1, 4.5f);
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); 
        }
    }
}
