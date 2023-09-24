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
    public AudioSource colletedClueAudio;
    //add clues and their answers here
    string[] clues = new string[]
    {
        "In copyright law, the 'fair use' doctrine allows limited use of copyrighted material without permission from the copyright owner. This is often applicable in cases of criticism, commentary, news reporting, teaching, and research.",
        "Trademark dilution occurs when a famous trademark's distinctive quality or reputation is weakened by the unauthorized use of a similar mark, even if there's no likelihood of consumer confusion",
        "Unlike patents, trademarks, and copyrights, which require public disclosure, trade secrets are protected through confidentiality agreements and security measures. Companies safeguard trade secrets to protect valuable business information.",
    };

    
    
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            clueIndex = UnityEngine.Random.Range(0, clues.Length);
            clueEvent.Invoke();
            textMeshProUGUI.SetText(clues[clueIndex]);
            StartCoroutine(ReadDelay());
            gameObject.SetActive(false);
        }
    }

    IEnumerator ReadDelay()
    {
        colletedClueAudio.Play();
        yield return new WaitForSecondsRealtime(5);
    }
}
