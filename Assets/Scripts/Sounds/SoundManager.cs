using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("-------- Audio Clip --------")]

    public AudioClip buttonHover;
    public AudioClip buttonClick;
    
    
    
    public void PlayButtonHover()
    {
        sfxSource.PlayOneShot(buttonHover);
    }
    
    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }
    
}
