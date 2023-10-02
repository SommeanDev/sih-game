using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Analytics : MonoBehaviour
{
    public TextMeshProUGUI creativeQuotientText;
    public TextMeshProUGUI innovativeQuotientText;
    public Image creativeQuotientImage;
    public Image innovativeQuotientImage;

    int creativeQuotient;
     int innovativeQuotient;

    void Start()
    {
        // Get the creative quotient and innovative quotient values from PlayerPrefs
        int creativeQuotient = PlayerPrefs.GetInt("CreativeQuotient");
        int innovativeQuotient = PlayerPrefs.GetInt("InnovativeQuotient");

        // Set the TextMeshPro text values
        creativeQuotientText.text = ""+ creativeQuotient + "%";
        innovativeQuotientText.text = ""+ innovativeQuotient+ "%";

        // Calculate fill amount for images (assuming a range of 0 to 100)
        float creativeFillAmount = creativeQuotient / 100.0f;
        float innovativeFillAmount = innovativeQuotient / 100.0f;

        // Set the fill amount for the Image components
        creativeQuotientImage.fillAmount = creativeFillAmount;
        innovativeQuotientImage.fillAmount = innovativeFillAmount;
    }

    void Update()
    {
          creativeQuotient = PlayerPrefs.GetInt("CreativeQuotient");
        innovativeQuotient = PlayerPrefs.GetInt("InnovativeQuotient");

    }

 

   
}

