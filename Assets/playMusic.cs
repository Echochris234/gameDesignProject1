﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    public AudioClip mainSong;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
