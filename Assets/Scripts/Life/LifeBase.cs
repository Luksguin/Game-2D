using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    public int startLife;

    public FlashPlayer flashPlayer;
    public AudioSource audioClipDamage;

    [Header("Player Settings")]
    public AudioSource audioClipKill;
    public GameObject uiLoseGame;

    private int _currentLife;
    private bool _isDead = false;

    [Header("Animation Death")]
    public Animator animator;
    public string boolDeath;
    public float deathTime;

    private void Awake()
    {
        Init();
        if (flashPlayer == null)
        {
            flashPlayer = GetComponent<FlashPlayer>();
        }
    }

    private void Init()
    {
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;
      
        PlayAudioDamage();

        if (_currentLife <= 0)
        {
            Kill();
            PlayAudioKill();
        }

        if (flashPlayer != null)
        {
            flashPlayer.Flash();
        }
    }

    public void Kill()
    {
        _isDead = true;

        animator.SetBool(boolDeath, true);
        Destroy(gameObject, deathTime);

        if (uiLoseGame != null) uiLoseGame.SetActive(true);
    }

    public void PlayAudioDamage()
    {
        if (audioClipDamage != null) audioClipDamage.Play();
    }

    public void PlayAudioKill()
    {
        if (audioClipKill != null) audioClipKill.Play();
    }
}