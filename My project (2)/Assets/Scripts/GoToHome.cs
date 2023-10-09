using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to access the UI components
using UnityEngine.SceneManagement;

public class GoToHome : MonoBehaviour
{
    public Image fillImage; // Reference to the Image component for the fill effect

    void Start()
    {
        // Start the fill effect when the script starts
        startHomePage();
    }

    public void startHomePage()
    {
        // Reset the fill amount to zero (empty)
        fillImage.fillAmount = 0f;

        // Invoke the filling function after a delay
        Invoke("FillImage", 1.5f);
    }

    private void FillImage()
    {
        // Create a Coroutine to gradually fill the image over 2 seconds
        StartCoroutine(FillImageCoroutine(2f));
    }

    private IEnumerator FillImageCoroutine(float duration)
    {
        float elapsedTime = 0f;
        float startFillAmount = fillImage.fillAmount;
        float targetFillAmount = 1f; // Fill the image completely

        while (elapsedTime < duration)
        {
          
            fillImage.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / duration);

        
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the fill amount is exactly 1 when the coroutine finishes
        fillImage.fillAmount = targetFillAmount;

        // Load the scene once the fill is complete
        SceneManager.LoadScene("MenuAndQuizScene");
    }
}

