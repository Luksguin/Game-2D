using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Animator animator;
    public string triggerAttack;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var life = collision.gameObject.GetComponent<LifeBase>();

        if(life != null)
        {
            life.Damage(damage);
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger(triggerAttack);
    }
}
