using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public delegate void KillHandler();

    public static event KillHandler onKill;
        // Start is called before the first frame update
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                onKill();
            }
        }
        
}
