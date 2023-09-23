using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClueTextHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] GameObject clueObject1;
    [SerializeField] GameObject clueObject2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject clueUIObject;

    [NonSerialized] public Dictionary<string, string> clueDict1 = new Dictionary<string, string>() {
        {"1", "This is a sample clue. its answer is one (1)." }
    };

    [NonSerialized] public Dictionary<string, string> clueDict2 = new Dictionary<string, string>() {
        {"2", "This is a sample clue. its answer is one (2)." }
    };

    private bool isReadingClue = false;

    void Update()
    {
        if (!isReadingClue && clueObject1.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            clueObject1.SetActive(false);
            StartCoroutine(ShowClue1());
        }

        if (!isReadingClue && clueObject2.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            clueObject2.SetActive(false);
            StartCoroutine(ShowClue2());
        }
    }

    IEnumerator ShowClue1()
    {
        isReadingClue = true;

        clueUIObject.SetActive(true);
        textMeshProUGUI.text = clueDict1["1"];
        Debug.Log(clueDict1["1"]);

        yield return new WaitForSecondsRealtime(5);

        Debug.Log("off");
        clueUIObject.SetActive(false);
        isReadingClue = false;
    }

    IEnumerator ShowClue2()
    {
        isReadingClue = true;

        clueUIObject.SetActive(true);
        textMeshProUGUI.text = clueDict2["2"];
        Debug.Log(clueDict2["2"]);

        yield return new WaitForSecondsRealtime(5);

        Debug.Log("off");
        clueUIObject.SetActive(false);
        isReadingClue = false;
    }

    
}

