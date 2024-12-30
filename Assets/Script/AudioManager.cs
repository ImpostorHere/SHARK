using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> cliplist;
    //public AudioClip clip;

    public AudioSource audioSource;
    public void PlayAudioOneShot(int index)
    {
        audioSource.PlayOneShot(cliplist[index]);
    } 
    

}