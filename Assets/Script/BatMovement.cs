using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float moveLeft;
    public float moveRight;
    private Rigidbody2D rb;
    public float moveCounter = 0;
    private bool goUp=true;
    private bool goDown=false;
    private int vert;
    
    // Start is called before the first frame update
    
    void Awake()
    {
        Kill.onKill += OnCharDeath;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.x >= 33)
        {

            rb.velocity = new Vector2(moveLeft, vert);
            transform.eulerAngles = Vector3.zero;
        }

        if (gameObject.transform.position.x  <=25 )
        {
            /*
            if (goUp)
            {
                vert = 1;
                goUp = false;
                goDown = true;
            }else if (goDown)
            {
                vert = -1;
                goDown = false;
                goUp = true;
            }
            */
            rb.velocity = new Vector2(moveRight, vert);
            transform.eulerAngles = new Vector3(0,180,0);
        }
            


    }
    
    void OnCharDeath()
    {
        
    }

    void OnDestroy()
    {
        Kill.onKill -= OnCharDeath;
    }
    
}
