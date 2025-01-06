using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<AudioClip> cliplist;
    //public AudioClip clip;

    public AudioSource audioSource;
    public void PlayAudioOneShot(int index)
    {
        audioSource.PlayOneShot(cliplist[index]);
    } 
    public void Awake()
    {
        Instance = this;
    }

    public void PlayRandomAudio(List<int> indexes)
    {
        int selectedIndex = Random.Range(0, indexes.Count);
        PlayAudioOneShot(indexes[selectedIndex]);
    }
}