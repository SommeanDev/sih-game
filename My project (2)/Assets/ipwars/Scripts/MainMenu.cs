using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is call before the first frame update
    public smove spaceship;
    public GameObject tutorial;

    void Start()
    {
        if (PlayerPrefs.GetInt("IPWarTutorial", 0) == 0)
        {
            ActivatePanel(tutorial);
            spaceship.pause();
            PlayerPrefs.SetInt("IPWarTutorial", 1);
            PlayerPrefs.Save();
        }

        else
        {
            DeActivatePanel(tutorial);
        }

    
       
    }

     public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeActivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


     public void mainmenu()
    {
        SceneManager.LoadScene("MenuAndQuizScene");
    }

    
}
