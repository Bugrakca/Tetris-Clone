using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    public static BackgroundMusic Instance;
    private void Awake()
    {
        if (Instance == null) {
            //First run, set the instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (Instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(gameObject);
            // Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
 
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
 
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
