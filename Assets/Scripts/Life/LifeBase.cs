using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    public int startLife;
    private int _currentLife;

    private bool _isDead = false;
    public bool destroyOnKill = false;

    private void Awake()
    {
        Init();
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
    }

    public void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
