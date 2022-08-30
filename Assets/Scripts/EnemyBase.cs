using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public SOEnemySetup soEnemySetup;
    public LifeBase lifeBase;

    public Animator animator;

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
    }

    public void Damage(int amount)
    {
        lifeBase.Damage(amount);
    }
}
