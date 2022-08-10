using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var life = collision.gameObject.GetComponent<LifeBase>();

        if(life != null)
        {
            life.Damage(damage);
        }
    }
}
