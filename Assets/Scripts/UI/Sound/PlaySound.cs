using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    public void Play()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
