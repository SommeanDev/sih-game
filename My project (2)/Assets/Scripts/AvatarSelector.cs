using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour
{
    public GameObject[] avatarImages; // An array to hold your avatar images
    public Button[] avatarButtons; // An array to hold your avatar selection buttons
    private int selectedAvatarIndex = -1; // Index of the selected avatar, initially set to -1 (none selected)

    void Start()
    {
        // Attach click handlers to the buttons
        for (int i = 0; i < avatarButtons.Length; i++)
        {
            int index = i; // Store the index in a local variable to avoid a closure issue
            avatarButtons[i].onClick.AddListener(() => SelectAvatar(index));
        }
    }

    void SelectAvatar(int index)
    {
        // Disable all avatar images
        foreach (GameObject image in avatarImages)
        {
            image.SetActive(false);
        }

        // Enable the selected avatar image
        avatarImages[index].SetActive(true);

        // Update the selectedAvatarIndex
        selectedAvatarIndex = index;

        // Save the selected avatar index
        PlayerPrefs.SetInt("SelectedAvatarIndex", selectedAvatarIndex);
        PlayerPrefs.Save();
    }
}
