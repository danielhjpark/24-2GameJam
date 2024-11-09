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
    [SerializeField]
    private CameraManager cameraManager;

    private void Start()
    {
        baseClip = audioSource.clip;
    }

    private void Update()
    {
        if(cameraManager.stageClear && audioSource.clip == changeClip)
        {
            ChangeSound(changeClip);
        }
        
        if(cameraManager.sceneDone)
        {
            ChangeSound(baseClip);
        }
    }

    public void ChangeSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
