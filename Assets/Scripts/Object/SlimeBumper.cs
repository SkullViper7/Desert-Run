using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBumper : MonoBehaviour
{
    bool onTop;
    GameObject bouncer;
    Animator anim;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (onTop)
        {
            anim.SetBool("isStepped", true);
            bouncer = other.gameObject;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTop= false;
        anim.SetBool("isStepped", false);
    }

    void Jump()
    {
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
