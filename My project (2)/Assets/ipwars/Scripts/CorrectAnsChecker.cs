using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CorrectAnsChecker : MonoBehaviour
{
    private Renderer rend;  // Reference to the Renderer component
    private Color originalColor;  // Store the original color
    private int iq;
    public TextMeshProUGUI correctAnswersText;
    private bool isVisible; // Flag to track if the GameObject is visible in the camera view

    public GameObject Gameover;
    

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
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(ChangeColorAndDestroy());
                iq += 1;
                PlayerPrefs.SetInt("IQ", iq);
                UpdateCorrectAnswersText();
            }
        }
    }

    private IEnumerator ChangeColorAndDestroy()
    {
        // Change the color to green
        rend.material.color = Color.green;
        print("wait");

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.2f);

        // Restore the original color
        rend.material.color = originalColor;

        // Destroy the GameObject
        Destroy(gameObject);
    }

    private IEnumerator Destroy()
    {
        // Change the color to green
        rend.material.color = Color.green;
        print("wait");

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.2f);

        // Restore the original color
        rend.material.color = originalColor;
        Time.timeScale = 0f;

        Gameover.SetActive(true);

        // Destroy the GameObject

        
        if (Time.timeScale == 1)
{
    // Destroy the gameObject
    Destroy(gameObject);

    // Reload the current scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
    }

    void UpdateCorrectAnswersText()
    {
        // Update the TextMeshProUGUI component with the correct answers count
        correctAnswersText.text = "" + iq;
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
    }
}


