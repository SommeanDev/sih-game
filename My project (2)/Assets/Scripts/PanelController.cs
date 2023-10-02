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
    public GameObject dailyPanel;
    public GameObject bgm;

    

     private void Start()
    {
        ActivatePanel(startPanel);
        if (PlayerPrefs.GetInt("IsSceneLoadedBefore", 0) == 0)
        {
            StartCoroutine(ActivateHomePanelAfterDelay(2.0f));
            PlayerPrefs.SetInt("IsSceneLoadedBefore", 1); 
        }
        else
        {
            ActivatePanel(homePanel);
        }
        bgm.SetActive(true);
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeActivatePanel(GameObject panel)
    {
        panel.SetActive(false);
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
    
    public void ActivateScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        // Call this method when you want to quit the game.
        PlayerPrefs.SetInt("IsSceneLoadedBefore", 0); // Reset the flag to 0
        PlayerPrefs.Save(); // Save the PlayerPrefs
        Application.Quit();
    }

    // Coroutine to activate the Home Panel after a delay
    private IEnumerator ActivateHomePanelAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        ActivatePanel(homePanel);
    }
}


