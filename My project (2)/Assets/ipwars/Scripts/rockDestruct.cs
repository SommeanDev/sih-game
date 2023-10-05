using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockDestruct : MonoBehaviour
{
    private bool isVisible = true; // Flag to track if the GameObject is visible in the camera view

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isVisible && collision.gameObject.CompareTag("Bullet"))
        {
            DestroyRock();
        }
    }

    private void DestroyRock()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }

    // Called when the GameObject becomes visible to any camera
    private void OnBecameVisible()
    {
        isVisible = true;
    }

    // Called when the GameObject is no longer visible to any camera
    private void OnBecameInvisible()
    {
        isVisible = false;
        DestroyRock(); // Destroy the GameObject when it becomes invisible
    }
}
