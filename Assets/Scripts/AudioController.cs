using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip backgrounMusic;
    public AudioClip steps;

    private AudioSource audioSource;

    void Awake()    
    {
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
       audioSource.clip = backgrounMusic;
       audioSource.Play();       
    }

    public void AudioSteps()
    { 
        audioSource.PlayOneShot(steps, 1f);
    }
    
}
