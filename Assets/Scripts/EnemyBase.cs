using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var life = collision.gameObject.GetComponent<LifeBase>();

        if(life != null)
        {
            life.Damage(damage);
        }
    }
}
