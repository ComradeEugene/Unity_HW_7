using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    private AudioSource fon;
    void Start()
    {
        fon = GetComponent<AudioSource>();
        fon.Play();
    }

    public void StopMusic()
    {
        if (fon.isPlaying)
        {
            fon.Pause();
        }
        else
        {
            fon.Play();
        }
    }
}
