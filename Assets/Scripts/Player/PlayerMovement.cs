using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Jump")]
    public int numberOfJumps = 0;
    public int maxNumberOfJumps = 1;
    public float jumpForce;

    [Header("Grounded")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    public bool isGrounded = false;

    [Header("WallJump")]
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    public float wallJumpForce = 5f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;

    [Header("Dash")]
    public float dashSpeed;
    bool canDash = true;
    public float currentDashTime;
    public float startDashTime;

    bool isReversed = false;
    bool crRunning = false;
    bool isWallJumping = false;

    Vector2 movement = Vector2.zero;

    Rigidbody2D rb = null;
    SpriteRenderer sp = null;
    Animator animator = null;

    private enum Movementstate {idle, run, jump, fall, dash}


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!isWallJumping)
        {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }

        bool isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if (isTouchingGround)
        {
            isGrounded = true;
            Debug.Log($"isGrounded : {isGrounded}");
        }
        else
        {
            isGrounded = false;
        }

        if (movement.x > 0)
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.cyan);
        }
        else if (movement.x < 0)
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.cyan);
        }
        
        if (WallCheckHit && !isGrounded && movement.x != 0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
            Debug.Log($"isWallSliding {isWallSliding}");
        }
        else if (jumpTime < Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            if (isReversed)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
            }
        }

        UpdateAnimationState();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.GetComponent<Bonus>();
        BonusBack bonusBack = collision.GetComponent<BonusBack>();
        if (bonus)
        {
            rb.gravityScale = -3f;
            isReversed = true;
            transform.eulerAngles = new Vector3(180, 0, 0);
            jumpForce = -10;
        }

        if (bonusBack)
        {
            rb.gravityScale = 3f;
            isReversed = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            jumpForce = 10;
        }
    }

    IEnumerator DashCoroutine(Vector2 direction)
    {
        crRunning = true;
        canDash = false;
        currentDashTime = startDashTime;
        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime;

            rb.velocity = direction * dashSpeed;

            yield return null;
        }

        rb.velocity = new Vector2(0f, 0f);

        canDash = true;
        crRunning = false;

    }

    public void OnJump(InputValue val)
    {


        if (isGrounded)
        {
            float innerValue = val.Get<float>();
            if (innerValue > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                Debug.Log("jump!");
            }
        }

        else if (isWallSliding)
        {
            isWallJumping = true;
            float innerValue = val.Get<float>();
            if (innerValue > 0)
            {
                if (movement.x > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(wallJumpForce, jumpForce), ForceMode2D.Impulse);
                }
                else if (movement.x > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(-wallJumpForce, jumpForce), ForceMode2D.Impulse);
                }
            }
            Invoke("StopWallJumping", 0.5f);
        }
    }

    void StopWallJumping()
    {
        isWallJumping = false;
    }
    public void OnMove(InputValue val)
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        movement = val.Get<Vector2>();
    }

    public void OnDash(InputValue val)
    {
        if (canDash && val.isPressed)
        {
            if (movement.x > 0)
            {
                StartCoroutine(DashCoroutine(Vector2.right));
            }
            else if (movement.x < 0)
            {
                StartCoroutine(DashCoroutine(Vector2.left));
            }
        }
    }

    private void UpdateAnimationState()
    {
        Movementstate State;

        if (movement.x > 0)
        {
            State = Movementstate.run;
            sp.flipX = false;
        }

        else if (movement.x < 0)
        {
            State = Movementstate.run;
            sp.flipX = true;
        }

        else
        {
            State = Movementstate.idle;
        }

        if (rb.velocity.y > .1f)
        {
            State = Movementstate.jump;
        }

        else if (rb.velocity.y < -.1f)
        {
            State = Movementstate.fall;
        }

        if (crRunning && movement.x < 0)
        {
            State = Movementstate.dash;
            sp.flipX = true;
        }

        else if (crRunning && movement.x > 0)
        {
            State = Movementstate.dash;
            sp.flipX = false;
        }

        animator.SetInteger("State", (int)State);
    }

}
