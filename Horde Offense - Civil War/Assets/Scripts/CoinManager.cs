using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int coins;

    private void Start()
    {
        UIManager.instance.setCoinText("Coins: " + coins);
    }

    public void changeCoin(int upCoin)
    {
        coins += upCoin;
        UIManager.instance.setCoinText("Coins: " + coins);
    }
}
