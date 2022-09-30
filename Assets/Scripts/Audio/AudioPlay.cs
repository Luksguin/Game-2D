using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource clip;

    public void Play()
    {
        clip.Play();
    }
}
