using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public LayerMask groundLayer;
    public float jumpForce = 400f;
    public float horizontalForce = 5f;
    //[SerializeField] private float fallingSpeed = 1.0f;
    public BoxCollider2D boxCollider;
    private float xMovement;
    private bool doubleJump = false;
    public static System.DateTime timeInitial;
    private enum MovementState { idle, running, jumping };


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        boxCollider = GetComponent<BoxCollider2D>();
        //groundLayer = GetComponent<LayerMask>();

        Debug.Log("Ground Layer: " + groundLayer.value);
        timeInitial = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = /*Input.GetAxisRaw("Horizontal");*/ SimpleInput.GetAxis("Horizontal");

        if (xMovement != 0)
        {
            if (xMovement < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (xMovement > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        if (IsGrounded() && !Input.GetButtonDown("Jump"))
        {
            doubleJump = false;
        }

        rb2d.velocity = new Vector2(xMovement * horizontalForce, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() || doubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                Debug.Log("Player Jumps");
                doubleJump = !doubleJump;
            }
        }

        UpdateAnimation();
    }

    public void Jump()
    {
        bool isJumping = false;
        if (IsGrounded() && (!Input.GetButtonDown("Jump") || !isJumping))
        {
            doubleJump = false;
        }

        if (IsGrounded() || doubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isJumping = true;
            Debug.Log("Player Jumps");
            doubleJump = !doubleJump;
        }

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (!IsGrounded() && rb2d.velocity == new Vector2(rb2d.velocity.x, 0.01f))
        {
            rb2d.gravityScale = 5;
        }
        else
        {
            rb2d.gravityScale = 1;
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (rb2d.velocity.x > .1f || rb2d.velocity.x < -.1f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb2d.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } 

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
