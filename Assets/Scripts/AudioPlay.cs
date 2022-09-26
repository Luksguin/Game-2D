using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public KeyCode buttonPlayAudio;
    public AudioSource clip;
    void Update()
    {
        if (Input.GetKeyDown(buttonPlayAudio))
        {
            clip.Play();
        }
    }
}
