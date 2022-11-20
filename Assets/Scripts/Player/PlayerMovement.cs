using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Jump")]
    public int numberOfJumps = 0;
    public int maxNumberOfJumps = 1;
    public float jumpForce;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    [Header("WallJump")]
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool isWallSliding = false;
    RaycastHit2D WallChechHit;
    float jumpTime;

    [Header("Dash")]
    public float dashSpeed;
    bool canDash = true;
    public float currentDashTime;
    public float startDashTime;

    private bool crRunning;

    Vector2 movement = Vector2.zero;

    Rigidbody2D rb = null;
    SpriteRenderer sp = null;
    Animator animator = null;

    private enum Movementstate { idle, run, jump, fall, dash}


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        UpdateAnimationState();

        if (movement.x > 0)
        {
            WallChechHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer);
        }
        else if (movement.x < 0)
        {
            WallChechHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, groundLayer);
        }

        if (WallChechHit && !isGrounded && movement.x != 0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if (jumpTime < Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.x, wallSlideSpeed, float.MaxValue));
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

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            numberOfJumps = maxNumberOfJumps;
        }
    }

    public void OnJump(InputValue val)
    {
        if (numberOfJumps > 0)
        {
            float innerValue = val.Get<float>();
            if (innerValue > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                numberOfJumps--;
            }
        }
    }

    public void OnMove(InputValue val)
    {
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