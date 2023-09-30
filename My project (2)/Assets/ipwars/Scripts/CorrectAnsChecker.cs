using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectAnsChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyIfInCameraFrame();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void DestroyIfInCameraFrame()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera not found.");
            return;
        }

        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the GameObject is within the camera's view
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
        {
            // Destroy the GameObject
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


