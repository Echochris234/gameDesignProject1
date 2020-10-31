using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    
    private PlayerController2D player;
    [SerializeField]
    private GameOver gameOver;


    private void Start()
    {
        player = new PlayerController2D();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerController2D>().itemCount++;
            Destroy(this.gameObject);

            if (col.GetComponent<PlayerController2D>().itemCount==5)
            {
                gameOver.gameObject.SetActive(true);
            }
            
        }
    }
}
