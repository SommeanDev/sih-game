using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.UI;

public class levelEnd : MonoBehaviour
{
    public UnityEvent levelEndEventScreen;
    public ClueTextHandler clueTextHandler;
    public GameObject clueObject;
    [SerializeField] private TextMeshProUGUI questionTextUGUI;
    public List<Button> optionButtons;

    [NonSerialized]
    public string[] questions =
    {
        "Which legal doctrine allows for the limited use of copyrighted material without the copyright owner's permission under certain circumstances?",
        "What is trademark dilution in intellectual property law?",
        "How are trade secrets primarily protected from disclosure?",
    };

    [NonSerialized]public string[][] options = new string[][]
    {
        new string[] {"Fair Use Doctrine", "Public Domain Doctrine" },
        new string[] {"A legal mechanism to enforce copyright claims", " The weakening of a famous trademark" },
        new string[] {"By confidentiality agreements", "Through copyright registration" },
    };

    [NonSerialized]public int[] queAnsIndexes = { 0,1,0, };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !clueObject.activeInHierarchy)
        {
            Debug.Log("Contacted player");
            levelEndEventScreen.Invoke();
            questionTextUGUI.text = questions[clueTextHandler.clueIndex];
            int i = 0;
            foreach (Button optionButton in optionButtons)
            {
                optionButton.GetComponentInChildren<TextMeshProUGUI>().SetText(options[clueTextHandler.clueIndex][i]);
                i++;
            }
        }
    }
}
