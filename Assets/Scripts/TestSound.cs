using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioClip AudioClip;
    private void OnTriggerEnter(Collider other)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(AudioClip);

        float lifetime = Mathf.Max(AudioClip.length);
        
        GameObject.Destroy(gameObject, lifetime );
    }
    
}
