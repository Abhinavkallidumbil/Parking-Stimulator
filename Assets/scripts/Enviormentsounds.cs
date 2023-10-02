using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviormentsounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip song;
    
    void Awake()
    {
        audioSource.PlayOneShot(song);
    }
}

