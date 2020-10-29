using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float moveLeft;
    public float moveRight;
    private Rigidbody2D rb;
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
        if (gameObject.transform.position.x >= 20)
        {

            rb.velocity = new Vector2(moveLeft, 0);
            transform.eulerAngles = Vector3.zero;
        }

        if (gameObject.transform.position.x  <=3 )
        {
            rb.velocity = new Vector2(moveRight, 0);
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
