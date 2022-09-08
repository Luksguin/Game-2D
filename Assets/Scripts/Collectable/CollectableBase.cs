using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string playerTag;
    public ParticleSystem systemParticle;

    [Header("Animations")]
    public Animator animator;
    public string setTrigger;
    public float destroyTime;

    private void Awake()
    {
        if(systemParticle != null) systemParticle.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerTag != null)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (systemParticle != null) systemParticle.Play();
        OnCollect();
        animator.SetTrigger(setTrigger);
        Destroy(gameObject, destroyTime);
    }

    protected virtual void OnCollect()
    {

    }
}
