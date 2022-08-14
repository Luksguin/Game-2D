using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string playerTag;

    [Header("Animations")]
    public Animator animator;
    public string setTrigger;

    public float destroyTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerTag != null)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        animator.SetTrigger(setTrigger);
        Destroy(gameObject, destroyTime);
    }

    protected virtual void OnCollect()
    {

    }
}
