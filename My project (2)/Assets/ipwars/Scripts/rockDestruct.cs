using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockDestruct : MonoBehaviour
{
    

     private Renderer rend;  // Reference to the Renderer component
    private Color originalColor;  // Store the original color

    private void Start()
    {
        // Get the Renderer component attached to the GameObject
        rend = GetComponent<Renderer>();

        // Store the original color
        originalColor = rend.material.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Destroy());
        }

       else if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeColorAndDestroy());
        }
    }



    private IEnumerator ChangeColorAndDestroy()
    {
        // Change the color to green
        rend.material.color = Color.red;
        print("wait");

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.2f);

        // Restore the original color
        rend.material.color = originalColor;

        // Destroy the GameObject
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }

     private IEnumerator Destroy()
    {
        // Change the color to green
        rend.material.color = Color.red;
        print("wait");

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0f);

        // Restore the original color
        rend.material.color = originalColor;

        // Destroy the GameObject
        Destroy(gameObject);

        // Reload the current scene
        
    }
}

