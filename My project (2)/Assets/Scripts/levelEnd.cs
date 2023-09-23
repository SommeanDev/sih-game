using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class levelEnd : MonoBehaviour
{
    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private GameObject mobileControlsPanel;
    [SerializeField] private TMP_Text timeTakenText;
    private TimeSpan duration;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndFlag")
        {
            Debug.Log("Level End");
            levelEndPanel.SetActive(true);
            if (mobileControlsPanel.activeSelf)
            {
                mobileControlsPanel.SetActive(false);
            }
            duration = DateTime.Now - PlayerInputMovement.timeInitial;
            Debug.Log(duration);
            timeTakenText.text = duration.ToString() + "s";
            Time.timeScale = 0f;
        }
    }
}
