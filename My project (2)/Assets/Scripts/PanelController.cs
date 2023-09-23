using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject startPanel; // Reference to the Start GameObject in the Unity Inspector
    public GameObject homePanel;  // Reference to the Home GameObject in the Unity Inspector
    public GameObject gamePanel;
    public GameObject quizPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, disable the homePanel and enable the startPanel
        startPanel.SetActive(true);
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        quizPanel.SetActive(false);
        
    }

    // Function to activate the Start Panel and deactivate the Home Panel
    public void ActivateStartPanel()
    {
        startPanel.SetActive(true);
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        quizPanel.SetActive(false);
       
    }

    // Function to activate the Home Panel and deactivate the Start Panel
    public void ActivateHomePanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(true);
        gamePanel.SetActive(false);
        quizPanel.SetActive(false);
        
    }

    public void ActivateGamePanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(false);
        gamePanel.SetActive(true);
        quizPanel.SetActive(false);

    }

    public void ActivateQuizPanel()
    {
        startPanel.SetActive(false);
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        quizPanel.SetActive(true);

    }



    

 
}

