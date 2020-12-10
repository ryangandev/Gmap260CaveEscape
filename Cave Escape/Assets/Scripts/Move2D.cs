using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    public SpriteRenderer sprite_renderer;
    public static bool spriteFlipped = false;
    public bool isGrounded;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

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
        Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
        Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Slope")) ||
        Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Slope")) ||
        Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Slope"));

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
            spriteFlipped = false;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-walkSpeed, rb2d.velocity.y);
            
            if (isGrounded)
                animator.Play("Pom_walk");
            sprite_renderer.flipX = true;
            spriteFlipped = true;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            rb2d.velocity = new Vector2(0,rb2d.velocity.y); 

            if(isGrounded)
                if(timeBtwAttack<=0)
                {
                    animator.Play("Attack");
                    SoundManager.PlaySound("swing");

                    timeBtwAttack = startTimeBtwAttack;
                }else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
        }

        //Idle animation + velocity stop when not moving (stops sliding)
        else
        {
            if (isGrounded){
                animator.Play("Pom_stand");
                RaycastHit2D hit = Physics2D.Linecast(transform.position, -Vector2.up, 1 << LayerMask.NameToLayer("Slope"));
		
		        if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f) {
			    Rigidbody2D body = GetComponent<Rigidbody2D>();
			    // Apply the opposite force against the slope force 
			    // You will need to provide your own slopeFriction to stabalize movement
			    body.velocity = new Vector2(body.velocity.x - (hit.normal.x * 0.6f), body.velocity.y);

			    //Move Player up or down to compensate for the slope below them
			    Vector3 pos = transform.position;
			    pos.y += -hit.normal.x * Mathf.Abs(body.velocity.x) * Time.deltaTime * (body.velocity.x - hit.normal.x > 0 ? 1 : -1);
			    transform.position = pos;
                }
            }
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
            SoundManager.PlaySound("coin");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }


}
