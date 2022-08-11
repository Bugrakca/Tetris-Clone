using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip hoverSound;

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
    
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
