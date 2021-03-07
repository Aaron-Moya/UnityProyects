using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float counter = 2f;
    public float waitTime = 2f;
    void Update()
    {
        counter += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter >= waitTime)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0f;
            }
        }
    }
}
