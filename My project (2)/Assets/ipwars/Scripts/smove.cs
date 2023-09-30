using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smove : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the forward movement speed
    public float maxRotationAngle = 25f; // Maximum rotation angle in degrees
    private Rigidbody2D rb2d;
    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private float currentRotationAngle = -10f; 
    public float rotationSpeed = 5f;
    public bool ispaused = false;
    private bool isButtonDownDown = false; 
    private bool isButtonDownUp = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Forward movement with constant velocity
       if(!ispaused)
       {
        Vector2 forwardVelocity = new Vector2(moveSpeed, rb2d.velocity.y);
        rb2d.velocity = forwardVelocity;
       }

        // Rotate the sprite smoothly
        float targetRotation = 0f;

        if (isMovingUp)
        {
            targetRotation = maxRotationAngle;
        }
        else if (isMovingDown)
        {
            targetRotation = -maxRotationAngle;
        }

        currentRotationAngle = Mathf.Lerp(currentRotationAngle, targetRotation, Time.deltaTime * rotationSpeed);
        RotateSprite(currentRotationAngle);

        if (!ispaused)
        {
            if (isButtonDownUp)
            {
                MoveUp();
            }
            else if (isButtonDownDown)
            {
                MoveDown();
            }
        }

     
    }

    // Function to move the sprite up when the "Up" button is pressed
    public void MoveUp()
    {
        Vector2 upwardVelocity = new Vector2(rb2d.velocity.x, moveSpeed);
        rb2d.velocity = upwardVelocity;
        isMovingUp = true;
        isMovingDown = false;
        
        // Start the coroutine with a 1-second delay
        StartCoroutine(DelayedStopVerticalMovement());
    }

    

    // Function to move the sprite down when the "Down" button is pressed
    public void MoveDown()
    {
        Vector2 downwardVelocity = new Vector2(rb2d.velocity.x, -moveSpeed);
        rb2d.velocity = downwardVelocity;
        isMovingDown = true;
        isMovingUp = false;
        StartCoroutine(DelayedStopVerticalMovement());
    }

    private IEnumerator DelayedStopVerticalMovement()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 1 second
        StopVerticalMovement(); // Call your method after the delay
    }

    // Function to stop the sprite's vertical movement when the buttons are released
 public void StopVerticalMovement()
{
    isMovingUp = false;
    isMovingDown = false;

    // Smoothly interpolate the rotation back to (0, 0, 0) over a longer duration
    StartCoroutine(LerpRotation(Quaternion.Euler(0f, 0f, 0f), 1.0f));
}

private IEnumerator LerpRotation(Quaternion targetRotation, float duration)
{
    float timeElapsed = 0f;
    Quaternion initialRotation = transform.rotation;

    while (timeElapsed < duration)
    {
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, timeElapsed / duration);
        timeElapsed += Time.deltaTime;
        yield return null;
    }

    // Ensure the final rotation is exactly the target rotation
    transform.rotation = targetRotation;
}


    // Rotate the sprite in the Z-direction
    private void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void pause()
    {
        ispaused = true;
        Vector2 ZeroVelocity = new Vector2(0f, 0f);
        rb2d.velocity = ZeroVelocity;
    }
    public void resume()
    {
        ispaused = false;
        
    }


   
    // Add these two functions to handle button press and release

    public void OnButtonDown(string buttonType)
    {
        if (buttonType == "Up")
        {
            isButtonDownUp = true;
        }
        else if (buttonType == "Down")
        {
            isButtonDownDown = true;
        }
    }

    public void OnButtonUp(string buttonType)
    {
        if (buttonType == "Up")
        {
            isButtonDownUp = false;
            StopVerticalMovement();
        }
        else if (buttonType == "Down")
        {
            isButtonDownDown = false;
            StopVerticalMovement();
        }
    }
}
