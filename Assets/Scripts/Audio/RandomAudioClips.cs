using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioClips : MonoBehaviour
{
    public List<AudioClip> listAudios;

    public AudioSource audioSource;

    public void RandomPlay()
    {
        audioSource.clip = listAudios[Random.Range(0, listAudios.Count)];
        audioSource.Play();
    }
}
