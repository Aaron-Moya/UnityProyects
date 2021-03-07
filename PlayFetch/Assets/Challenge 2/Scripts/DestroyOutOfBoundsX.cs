using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30f;
    private float bottomLimit = 0.23f;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (this.gameObject.CompareTag("Balls") && transform.position.y < bottomLimit)
        {
            Debug.Log("Game Over...");
            Time.timeScale = 0f;
        }

    }
}
