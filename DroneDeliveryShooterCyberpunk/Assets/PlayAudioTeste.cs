using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioTeste : MonoBehaviour
{
    AudioSource hitSound;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    public void Play()
    {
        hitSound.Play();
    }
}
