using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject homePanel;  
    public GameObject gamePanel;
    public GameObject profileMaking;
    public GameObject bgm;

    private void Start()
    {
        // Check if the tutorial has been shown before
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 0)
        {
            // Tutorial has not been shown, so activate it
            ActivatePanel(profileMaking);
            // Set the flag to indicate that the tutorial has been shown
            PlayerPrefs.SetInt("TutorialShown", 1);
            PlayerPrefs.Save();
        }
        else
        {
            // PlayerPrefs.SetInt("TutorialShown", 0);
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

        PlayerPrefs.SetInt("IsSceneLoadedBefore", 0); 
        PlayerPrefs.Save(); 
        Application.Quit();
    }

}


