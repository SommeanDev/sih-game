using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject tutorial;
    public smove PAUSE;

    int TutorialSceneShown;

    void Awake()
    {
        // Initialize TutorialSceneShown with PlayerPrefs data.
        TutorialSceneShown = PlayerPrefs.GetInt("IPWarTutorial");
    }

    void Start()
    {
        AudioSource spaceshipAudio = spaceship.GetComponent<AudioSource>();

        if (TutorialSceneShown == 0)
        {
            ActivatePanel(tutorial);
            PAUSE.pause();

            if (spaceshipAudio != null)
            {
                spaceshipAudio.Pause();
            }

            TutorialSceneShown++;
            PlayerPrefs.SetInt("IPWarTutorial", TutorialSceneShown);
            PlayerPrefs.Save();
        }
        else
        {
            DeActivatePanel(tutorial);
            spaceshipAudio.Play();
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
        // Optionally, reset PlayerPrefs when returning to the main menu
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuAndQuizScene");
    }
}
