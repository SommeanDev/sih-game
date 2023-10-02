using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RPGPlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = SimpleInput.GetAxisRaw("Horizontal");
        float yInput = SimpleInput.GetAxisRaw("Vertical");
        rigidbody2D.velocity = new Vector3(xInput * moveSpeed, yInput * moveSpeed);
    }
}
