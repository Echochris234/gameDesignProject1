﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
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
        
    }
    
    void OnCharDeath()
    {
        
    }

    void OnDestroy()
    {
        Kill.onKill -= OnCharDeath;
    }
}
