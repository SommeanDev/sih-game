using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject startPanel; 
    public GameObject homePanel;  
    public GameObject gamePanel;
    public GameObject quizPanel;
    public GameObject bgm;

    

     private void Start()
    {
          ActivateStartPanel();
        if (PlayerPrefs.GetInt("IsSceneLoadedBefore", 0) == 0)
        {
            // This is the first load of the scene
            StartCoroutine(ActivateHomePanelAfterDelay(2.0f));
            PlayerPrefs.SetInt("IsSceneLoadedBefore", 1); // Set the flag to indicate the scene has been loaded
        }
        else
        {
            // This is not the first load, activate the game panel immediately
            ActivateGamePanel();
        }
    }


    public void ActivateStartPanel()
    {
        startPanel.SetActive(true);
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        quizPanel.SetActive(false);
        bgm.SetActive(false);
    }

    // Function to activate the Home Panel and deactivate the Start Panel
    public void ActivateHomePanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(true);
        gamePanel.SetActive(false);
        quizPanel.SetActive(false);
        bgm.SetActive(true);
    }

    public void ActivateGamePanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(false);
        gamePanel.SetActive(true);
        quizPanel.SetActive(false);
        bgm.SetActive(true);
    }

    public void ActivateQuizPanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        quizPanel.SetActive(true);
        bgm.SetActive(false);
    }

    public void StartLoadingSlugSceneWithDelay()
{
    // Set the PlayerPrefs flag to indicate that the scene has been loaded before
    PlayerPrefs.SetInt("IsSceneLoadedBefore", 1);

    // Call ActivateSlugScene with a delay of 0.2 seconds
    Invoke("ActivateSlugScene", 1.5f);
}

private void ActivateSlugScene()
{
    SceneManager.LoadScene("SAdv_Lvl01");
}

    public void QuitGame()
    {
        PlayerPrefs.SetInt("IsSceneLoadedBefore", 0); // Reset the flag to 0
        PlayerPrefs.Save(); // Save the PlayerPrefs
        Application.Quit();

    }

    // Coroutine to activate the Home Panel after a delay
    private IEnumerator ActivateHomePanelAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        ActivateHomePanel();
    }
}


