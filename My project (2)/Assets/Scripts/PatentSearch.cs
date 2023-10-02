using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatentSearch : MonoBehaviour
{
    public TMP_InputField searchInputField;

    public void SearchGooglePatents()
    {
        string query = searchInputField.text;
        string url = "https://patents.google.com/?q=" + query;

        // Open the Google Patents website in a browser
        Application.OpenURL(url);
    }
}
