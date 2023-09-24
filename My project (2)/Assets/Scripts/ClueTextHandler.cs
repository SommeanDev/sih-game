using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using System.Collections;

public class ClueTextHandler : MonoBehaviour
{
    public UnityEvent clueEvent;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] GameObject clueUIObject;
    [NonSerialized] public int clueIndex;
    //add clues and their answers here
    string[] clues = new string[]
    {
        "This is a sample Clue. its answer is one",
    };
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            clueIndex = UnityEngine.Random.Range(0, clues.Length);
            clueEvent.Invoke();
            textMeshProUGUI.SetText(clues[clueIndex]);
            StartCoroutine(ReadDelay());
            //clueUIObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    IEnumerator ReadDelay()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}
