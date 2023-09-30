using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is called when a collision occurs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the "bullet" tag
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the rock (this GameObject)
            Destroy(gameObject);
        }
    }
}

