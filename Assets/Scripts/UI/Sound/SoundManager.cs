using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip changeClip;
    [SerializeField] 
    private AudioClip baseClip;

    private void Start()
    {
        baseClip = audioSource.clip;
    }

    private void Update()
    {
    }

    public void ChangeSound()
    {
        audioSource.clip = changeClip;
        audioSource.Play();
    }

    public void ReturnSound()
    {
        audioSource.clip = baseClip;
        audioSource.Play();
    }
}
