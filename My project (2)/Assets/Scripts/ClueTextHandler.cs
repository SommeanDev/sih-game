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

    //add clues and their answers here
    [NonSerialized] public Dictionary<string, string> clueDict = new Dictionary<string, string>() {
        {"1", "This is a sample clue. its answer is one (1)." }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clueObject.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>())){
            clueUIObject.SetActive(true);
            //and update/change this
            textMeshProUGUI.text = clueDict["1"];
            Debug.Log(clueDict["1"]);
            StartCoroutine(ReadDelay());
            Debug.Log("off");
            clueUIObject.SetActive(false);
            clueObject.SetActive(false);
        }
    }

    IEnumerator ReadDelay()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}
