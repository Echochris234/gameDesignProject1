using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.LowLevel;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController2D : MonoBehaviour
{

    //public static PlayerController2D instance;
    private Animator animator;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public float movespeed;

    private bool isGrounded;
    
    [SerializeField]
    private Transform groundCheck;
    
    [SerializeField]
    private TextMeshProUGUI lives;

    [SerializeField]
    private GameOver gameOver;
    
    //combat

    private int health = 6;

    private float invinsibleTimeafterHurt = 3;
    private bool movementDisabled;
    
    Collider2D[] myCols;
    // Start is called before the first frame update
    void Start()
    {
      //  instance = this;
        myCols = this.GetComponents<Collider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movementDisabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (movementDisabled)
            return;
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
        
        lives.text = "Lives: " + health/2;
        
    }

   void Hurt()
   {
       health--;
       if (health <= 0)
       {
           
           //Application.LoadLevel(Application.loadedLevel);
           GetComponent<BoxCollider2D>().enabled = false;
           gameOver.gameObject.SetActive(true);
           movementDisabled = true;
           lives.text = "Lives: " + 0;


       }
       else
       {
           StartCoroutine(hurtBlinker());
           animator.Play("Player_Damaged");
       }
   }

   IEnumerator hurtBlinker()
   {
       //ignore collision btwe enmeies and players
       int enemyLayer = LayerMask.NameToLayer("Enemy");
       int playerLayer = LayerMask.NameToLayer("Player");
       Physics2D.IgnoreLayerCollision(enemyLayer,playerLayer);
       foreach(Collider2D collider in myCols)
       {
           collider.enabled = false;
           collider.enabled = true;
           
       }
       
       // start animation
       animator.SetLayerWeight(1,1);
       
       // wait
       yield return new WaitForSeconds(invinsibleTimeafterHurt);
       
       //re enable
       Physics2D.IgnoreLayerCollision(enemyLayer,playerLayer,false);
       animator.SetLayerWeight(1,0);
       
   }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GhostMovement ghost= col.collider.GetComponent<GhostMovement>();
        BatMovement bat = col.collider.GetComponent<BatMovement>();
        if (bat != null||ghost!=null)
        {
            /*foreach (ContactPoint2D point in col.contacts)
            {
                Debug.Log(point.normal);
                Debug.DrawLine(point.point,point.point+point.normal,Color.red,10);
                if (point.normal.y >= 0.9)
                {
                    if(ghost!=null)
                        ghost.Hurt();
                    else if (bat != null)
                        bat.Hurt();
                }
                else
                {*/
                    Hurt();   
            //     }
            // }
            // {
            //     
            // }
            
        }
    }
}
