using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    public TextMeshProUGUI coinAmount;

    public int currentCoins;

    private void Awake()
    {
        if(Instance == null)
           Instance = this;
        else
           Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        currentCoins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coinAmount.text = currentCoins.ToString();
        currentCoins += amount;
    }
}
