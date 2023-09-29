using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    // This method is called when the bullet collides with another object.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the object you want to destroy the bullet.
        // Change "Target" to the appropriate tag of the object you want to collide with.
        
            // Destroy the bullet GameObject.
            Destroy(gameObject);
        
    }
}