using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleBase : MonoBehaviour
{
    public Vector2 speed;
    public float timeToDestroy;
    public float side;
    public int damageAmount;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * side);
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
