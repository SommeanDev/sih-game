using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smove : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Adjust this to control the forward movement speed
    public float maxRotationAngle = 25f; // Maximum rotation angle in degrees
    private Rigidbody2D rb2d;
    private bool isMovingUp = false;
    private bool isMovingDown = false;
    private float currentRotationAngle = -10f; 
    public float rotationSpeed = 2.5f;
    public bool ispaused = false;
    private bool isButtonDownDown = false; 
    private bool isButtonDownUp = false;
    public float smoothTime = 0.2f; // Adjust this value to control the smoothing effect
private Vector2 velocity = Vector2.zero;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Forward movement with constant velocity
       if(!ispaused)
       {
        Vector2 forwardVelocity = new Vector2(moveSpeed, rb2d.velocity.y);
        rb2d.velocity = forwardVelocity; 
        Vector3 gyroRotationRate = Input.gyro.rotationRate;
        float targetRotation = 0f;

        // if (isMovingUp)
        // {
        //     targetRotation = maxRotationAngle;
        // }
        // else if (isMovingDown)
        // {
        //     targetRotation = maxRotationAngle;
        // }
       if (Mathf.Abs(gyroRotationRate.z) > 0.1f)
            {
                targetRotation = Mathf.Clamp(gyroRotationRate.z * maxRotationAngle, -maxRotationAngle, maxRotationAngle);
            }

        currentRotationAngle = Mathf.Lerp(currentRotationAngle, targetRotation, Time.deltaTime * rotationSpeed);
        RotateSprite(currentRotationAngle);

   
    // Check gyroscope rotation
   
    if (Mathf.Abs(gyroRotationRate.z) > 0.1f)
    {
        
            MoveUp(targetRotation);
        
    }
}
 
}

     
    

    public void MoveUp(float targetRotation)
{
    isMovingUp = true;
    isMovingDown = false;

    // Calculate the desired velocity
    Vector2 targetVelocity = new Vector2(rb2d.velocity.x, targetRotation / 2);

    // Smoothly interpolate the velocity
    rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, smoothTime);
}




    private void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle*2);
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
}
