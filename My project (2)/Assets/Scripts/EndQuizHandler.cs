using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndQuizHandler : MonoBehaviour
{
    [SerializeField] ClueTextHandler clueTextHandler;
    [SerializeField] levelEnd lvlEndScript;
    public UnityEvent correctAnsScene;
    public UnityEvent incorrectAnsScene;
    private int iq;

    public void CheckAnswer(TextMeshProUGUI textMesh)
    {
        if (textMesh.text == lvlEndScript.options[clueTextHandler.clueIndex][lvlEndScript.queAnsIndexes[clueTextHandler.clueIndex]])
        {
            correctAnsScene.Invoke();
            iq += 5;
            PlayerPrefs.SetInt("IQ", iq);
        }
        else
        {
            incorrectAnsScene.Invoke();
        }
    }
}