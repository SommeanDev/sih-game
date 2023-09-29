using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copyposition : MonoBehaviour
{
    public GameObject sourceObject; // Assign the source GameObject in the Unity Inspector
    public Camera cameraToUse; // Assign the camera in the Unity Inspector

    // Update is called once per frame
    void Update()
    {
        if (sourceObject != null && cameraToUse != null)
        {
            // Get the position of the sourceObject in screen space
            Vector3 screenPos = cameraToUse.WorldToScreenPoint(sourceObject.transform.position);

            // Convert the screen position to world position for this GameObject
            Vector3 worldPos = cameraToUse.ScreenToWorldPoint(screenPos);

            // Set the position of this GameObject to match the sourceObject's position
            transform.position = worldPos;
        }
        else
        {
            Debug.LogWarning("Please assign the sourceObject and cameraToUse in the Inspector.");
        }
    }
}
