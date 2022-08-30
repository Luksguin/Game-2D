using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;
    private GameObject _currentPlayer;

    [Header("Animation")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
       // _currentPlayer = Instantiate(player);
        player.transform.position = startPoint.transform.position;
        player.transform.DOScale(0, duration).SetEase(ease).SetDelay(delay).From();
    }
}
