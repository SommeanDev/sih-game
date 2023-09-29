// Example using Unity's Input system
using UnityEngine;
using UnityEngine.InputSystem;

public class YourInputHandler : MonoBehaviour
{
    private smove movementScript;

    private void Start()
    {
        movementScript = GetComponent<smove>();
    }

    public void OnUpButtonReleased(InputAction.CallbackContext context)
    {
        // Call StopVerticalMovement when the "Up" button is released
        if (context.phase == InputActionPhase.Canceled)
        {
            movementScript.StopVerticalMovement();
        }
    }

    public void OnDownButtonReleased(InputAction.CallbackContext context)
    {
        // Call StopVerticalMovement when the "Down" button is released
        if (context.phase == InputActionPhase.Canceled)
        {
            movementScript.StopVerticalMovement();
        }
    }
}

