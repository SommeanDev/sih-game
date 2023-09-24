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

    public void CheckAnswer(TextMeshProUGUI textMesh)
    {
        if (textMesh.text == lvlEndScript.options[clueTextHandler.clueIndex][lvlEndScript.queAnsIndexes[clueTextHandler.clueIndex]])
        {
            correctAnsScene.Invoke();
        }
        else
        {
            incorrectAnsScene.Invoke();
        }
    }
}
