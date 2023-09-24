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
        "What was the answer of the first clue?",
    };

    [NonSerialized]public string[][] options = new string[][]
    {
        new string[] {"one", "1" },

    };

    [NonSerialized]public int[] queAnsIndexes = { 0, };

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
