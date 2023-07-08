using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coin = 1;
    public int getCoin()
    {
        return coin;
    }
}
