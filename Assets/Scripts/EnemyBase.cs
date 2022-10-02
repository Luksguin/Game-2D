using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public SOEnemySetup soEnemySetup;
    public LifeBase lifeBase;

    public Animator animator;

    public AudioSource audioClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var life = collision.gameObject.GetComponent<LifeBase>();

        if(life != null)
        {
            life.Damage(soEnemySetup.damage);
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger(soEnemySetup.triggerAttack);
        PlayAudioEnemy();
    }

    public void PlayAudioEnemy()
    {
        if (audioClip != null) audioClip.Play();
    }

    public void Damage(int amount)
    {
        lifeBase.Damage(amount);
    }
}
