using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    public int startLife;
    private int _currentLife;

    private bool _isDead = false;

    public FlashPlayer flashPlayer;

    [Header("Animation Death")]
    public Animator animator;
    public string boolDeath;
    public float deathTime;

    private void Awake()
    {
        Init();
        if(flashPlayer == null)
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
        if(_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }

        if(flashPlayer != null)
        {
            flashPlayer.Flash();
        }
    }

    public void Kill()
    {
        _isDead = true;

        animator.SetBool(boolDeath, true);

        Destroy(gameObject, deathTime);
    }
}
