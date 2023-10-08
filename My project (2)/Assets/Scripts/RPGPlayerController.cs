using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RPGPlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = SimpleInput.GetAxisRaw("Horizontal");

        if (xInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        float yInput = SimpleInput.GetAxisRaw("Vertical");
        rigidbody2D.velocity = new Vector2(xInput * moveSpeed, yInput * moveSpeed);

        if (rigidbody2D.velocity != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        animator.SetBool("isWalking", isMoving);
    }
}
