using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is call before the first frame update
     public void mainmenu()
    {
        SceneManager.LoadScene("MenuAndQuizScene");
    }

    
}
