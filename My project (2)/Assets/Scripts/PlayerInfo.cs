using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_InputField dobInput;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI ageDisplay;
    public TextMeshProUGUI dobDisplay;

    private string playerName;
    private string playerAge;
    private string playerDOB;

    void Start()
    {
        // Load the saved player information
        playerName = PlayerPrefs.GetString("PlayerName", "");
        playerAge = PlayerPrefs.GetString("PlayerAge","");
        playerDOB = PlayerPrefs.GetString("PlayerDOB", "");

        // Update the input fields and display with loaded data
        nameInput.text = playerName;
        ageInput.text = playerAge;
        dobInput.text = playerDOB;

        UpdateDisplay();
    }

    public void DisplayInfo()
    {
        playerName = nameInput.text;
        playerAge = ageInput.text;
        playerDOB = dobInput.text;

        // Save player information
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetString("PlayerAge", playerAge);
        PlayerPrefs.SetString("PlayerDOB", playerDOB);
        PlayerPrefs.Save();

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        nameDisplay.text = "Name: " + playerName;
        ageDisplay.text = "Age: " + playerAge;
        dobDisplay.text = "D.O.B: " + playerDOB;
    }
}


