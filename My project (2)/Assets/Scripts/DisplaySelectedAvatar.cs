using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedAvatar : MonoBehaviour
{
    public GameObject[] avatarImages; // An array to hold your avatar images
    int selectedAvatarIndex;

    void Start()
    {
        selectedAvatarIndex = PlayerPrefs.GetInt("SelectedAvatarIndex", -1);
    }

    void Update()
{
    selectedAvatarIndex = PlayerPrefs.GetInt("SelectedAvatarIndex");

    // Disable all avatar images first
    for (int i = 0; i < avatarImages.Length; i++)
    {
        if (avatarImages[i] != null)
        {
            avatarImages[i].SetActive(false);
        }
    }

    if (selectedAvatarIndex != -1 && selectedAvatarIndex < avatarImages.Length)
    {
        // Activate only the selected avatar image
        avatarImages[selectedAvatarIndex].SetActive(true);
    }
}

}

