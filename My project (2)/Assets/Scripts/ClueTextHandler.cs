using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class ClueTextHandler : MonoBehaviour
{
    public UnityEvent clueEvent;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] GameObject clueUIObject;

    //add clues and their answers here
    [NonSerialized] public Dictionary<string, string> clueDict = new Dictionary<string, string>() {
        {"1", "This is a sample clue. its answer is one (1)." }
    };

   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            clueEvent.Invoke();
            textMeshProUGUI.SetText(clueDict["1"]);
            StartCoroutine(ReadDelay());
            //clueUIObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    IEnumerator ReadDelay()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}
