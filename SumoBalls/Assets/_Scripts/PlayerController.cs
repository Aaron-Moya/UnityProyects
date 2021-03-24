using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;

    public GameObject focalPoint;

    private float forwardInput;

    public bool hasPoweUp;
    public float powerUpForce;
    public float powerUpCoolDown;
    public GameObject[] powerUpIndicators;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * (moveForce * forwardInput));

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position;  // + 0.5f * Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPoweUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPoweUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - this.transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpCoolDown/powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);  
        }
        
        hasPoweUp = false;
    }
}
