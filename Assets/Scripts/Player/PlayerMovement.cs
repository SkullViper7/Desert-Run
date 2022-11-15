using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int numberOfJumps = 0;
    public int maxNumberOfJumps = 1;
    public float jumpForce;

    Vector2 movement = Vector2.zero;

    Rigidbody2D rb = null;
    SpriteRenderer sprite = null;
    Animator animator = null;

    private enum Movementstate { idle, run, jump, fall }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        UpdateAnimationState();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        if (contact.normal.y > 0.7f)
        {
            numberOfJumps = maxNumberOfJumps;
        }
    }
    public void OnJump(InputValue val)
    {
        if (numberOfJumps <= 0)
        {
            return;
        }
        float innerValue = val.Get<float>();
        if (innerValue > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            numberOfJumps--;
        }
    }

    public void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
    }

    private void UpdateAnimationState()
    {
        Movementstate State;

        if (movement.x > 0)
        {
            State = Movementstate.run;
            sprite.flipX = false;
        }

        else if (movement.x < 0)
        {
            State = Movementstate.run;
            sprite.flipX = true;
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

        animator.SetInteger("State", (int)State);
    }

}
