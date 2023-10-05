using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Incorrectans : MonoBehaviour
{
    private Renderer rend;  // Reference to the Renderer component
    private Color originalColor;  // Store the original color
    private int iq;
    public TextMeshProUGUI correctAnswersText;
    private bool isVisible; 

    private void Start()
    {
        // Get the Renderer component attached to the GameObject
        rend = GetComponent<Renderer>();

        // Store the original color
        originalColor = rend.material.color;
         iq += PlayerPrefs.GetInt("IQ");
        
        UpdateCorrectAnswersText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (isVisible)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Destroy());
             iq += 1;
            PlayerPrefs.SetInt("IQ", iq);
            UpdateCorrectAnswersText();
        }
        

       else if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeColorAndDestroy());
        }
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
        yield return new WaitForSeconds(0.1f);

        // Restore the original color
        rend.material.color = originalColor;

        // Destroy the GameObject
        Destroy(gameObject);

        // Reload the current scene
        
    }
     void UpdateCorrectAnswersText()
    {
        // Update the TextMeshProUGUI component with the correct answers count
        correctAnswersText.text = ""+iq;
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    // Called when the GameObject is no longer visible to any camera
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
}
