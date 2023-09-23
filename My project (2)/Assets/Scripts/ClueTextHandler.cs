using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClueTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] GameObject clueObject;
    [SerializeField] GameObject player;
    [SerializeField] GameObject clueUIObject;

    [NonSerialized] public Dictionary<string, string> clueDict = new Dictionary<string, string>() {
        {"1", "This is a sample clue. its answer is one (1)." }
    };

    private bool isReadingClue = false;

    void Update()
    {
        if (!isReadingClue && clueObject.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            clueObject.SetActive(false);
            StartCoroutine(ShowClue());
        }
    }

    IEnumerator ShowClue()
    {
        isReadingClue = true;

        clueUIObject.SetActive(true);
        textMeshProUGUI.text = clueDict["1"];
        Debug.Log(clueDict["1"]);

        yield return new WaitForSecondsRealtime(5);

        Debug.Log("off");
        clueUIObject.SetActive(false);
        isReadingClue = false;
    }
}

