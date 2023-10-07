using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject homePanel;  
    public GameObject gamePanel;
    public GameObject bgm;

    private void Start()
    {
        ActivatePanel(homePanel); 
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


