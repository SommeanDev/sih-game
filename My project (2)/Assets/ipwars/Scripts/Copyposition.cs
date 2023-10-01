using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copyposition : MonoBehaviour
{
    public Transform target; // Reference to the target GameObject whose position you want to copy.
    private bool isYOutOfRange = false;
    private float previousY;

    void Start()
    {
        if (target != null)
        {
            previousY = target.position.y;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Copy the X position from the target GameObject.
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

            float currentY = target.position.y;

            // Check if the Y position is beyond the -10f to 10f range.
            if (currentY < -5.5f || currentY > -1.5f)
            {
                isYOutOfRange = true;
            }
            else
            {
                isYOutOfRange = false;
            }

            // Copy the Y direction motion only when it's out of range.
            if (isYOutOfRange)
            {
                float deltaY = currentY - previousY;
                transform.position += Vector3.up * deltaY;
            }

            previousY = currentY;
        }
    }
}


