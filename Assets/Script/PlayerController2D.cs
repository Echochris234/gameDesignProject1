using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public float movespeed;

    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platforms")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if(isGrounded)
                animator.Play("Player_Run");
            spriteRenderer.flipX = true;
            
        } else if (Input.GetKey(KeyCode.D)){
            
            rb.velocity = new Vector2(+movespeed, rb.velocity.y);
            if(isGrounded)
                animator.Play("Player_Run");
            spriteRenderer.flipX = false;
            //transform.eulerAngles=Vector3.zero;
        }
        else
        {
            if(isGrounded)
                animator.Play("Player Idle");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded==true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 23);
            animator.Play("Player_Jump");
        }
    }
    
}
