using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float bottomBound = -10f;
    
    void Update()
    {
        //Destruir objeto si se sale del borde del juego
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }
        
        if (this.transform.position.z < bottomBound)
        {
            Debug.Log("Game Over...");
            Destroy(this.gameObject);

            Time.timeScale = 0;
        }
    }
}
