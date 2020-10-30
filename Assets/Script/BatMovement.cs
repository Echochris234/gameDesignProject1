using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float moveLeft;
    public float moveRight;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
   
 
    
    void Awake()
    {
        Kill.onKill += OnCharDeath;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.transform.position.x >= 33)
        {

            rb.velocity = new Vector2(moveLeft, 0);
            spriteRenderer.flipX = false;
        }

        if (gameObject.transform.position.x  <=25 )
        {
          
            rb.velocity = new Vector2(moveRight, 0);
            spriteRenderer.flipX = true;
        }
            


    }
    
    public void Hurt()
    {
        
        Destroy(this.gameObject);
    }
    void OnCharDeath()
    {
        
    }

    void OnDestroy()
    {
        Kill.onKill -= OnCharDeath;
    }
    
}
