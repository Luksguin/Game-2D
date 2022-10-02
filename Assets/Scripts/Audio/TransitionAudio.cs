using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TransitionAudio : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float timeToTranzition;

    public void Transition()
    {
        snapshot.TransitionTo(timeToTranzition);
    }
}
