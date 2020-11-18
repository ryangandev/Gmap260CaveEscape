using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer sprite_renderer;

    public bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    private float walkSpeed = 2;

    [SerializeField]
    private float jumpSpeed = 3;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        //checks if player is grounded
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
        Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
        Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"));

        if(isGrounded == false)
        {
            animator.Play("Pom_jump");
        }

        //Left and Right character control inputs
        if(Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(walkSpeed, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("Pom_walk");
            sprite_renderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-walkSpeed, rb2d.velocity.y);
            
            if (isGrounded)
                animator.Play("Pom_walk");
            sprite_renderer.flipX = true;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            rb2d.velocity = new Vector2(0,0); 

            if(isGrounded)
                animator.Play("Attack");
        }

        //Idle animation + velocity stop when not moving (stops sliding)
        else
        {
            if (isGrounded)
                animator.Play("Pom_stand");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        //Jump character control input
        if(Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Pom_jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }


}
