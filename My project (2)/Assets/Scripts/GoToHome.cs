using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHome : MonoBehaviour
{
    void Start()
    {
        startHomePage();
    }

    public void startHomePage()
    {
        Invoke("ActivateHomeScene", 1.5f);
    }

    private void ActivateHomeScene()
    {
       SceneManager.LoadScene("MenuAndQuizScene");
    }
}
