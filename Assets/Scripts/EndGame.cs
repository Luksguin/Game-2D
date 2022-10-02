using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string tagToCompare;
    public GameObject uiEndGame;
    public AudioSource clipAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToCompare))
        {
            callEndGame();
        }
    }

    public void callEndGame()
    {
        uiEndGame.SetActive(true);
        PlayAudioWin();
    }

    public void PlayAudioWin()
    {
        if(clipAudio != null)
        {
            clipAudio.Play();
        }
    }
}
