using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Vector2 movement = Vector2.zero;

    Rigidbody2D rb = null;
    SpriteRenderer sr = null;
    Animator animator = null;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

    }
    public void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
    }

}
