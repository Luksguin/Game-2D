using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashPlayer : MonoBehaviour
{
    public List<SpriteRenderer> spritesRenderers;
    public Color color;
    public float duration;
    private Tween _currentTween;

    private void OnValidate()
    {
        spritesRenderers = new List<SpriteRenderer>();

        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spritesRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spritesRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var s in spritesRenderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
