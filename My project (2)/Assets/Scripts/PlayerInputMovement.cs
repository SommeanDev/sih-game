using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask groundLayer;
    private bool doubleJump;
    private enum MovementState { idle, running, jumping, falling };
    MovementState state;
    public float jumpForce = 10f;
    public float speed = 10f;
    private Vector2 movement;
    public static DateTime timeInitial;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timeInitial = DateTime.Now;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && context.canceled)
        {
            doubleJump = false;
        }

        if (context.started)
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Debug.Log("Player Jumps " + context);
                doubleJump = !doubleJump;
            }
        }
    }
    public void Walk(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        if (rb.velocity.x < -.1f)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.x != 0)
        {
            state = MovementState.running;
        } else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
