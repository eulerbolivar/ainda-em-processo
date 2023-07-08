using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int life;

    private void Start()
    {
        UIManager.instance.setLifeText("Life: " + life);
    }

    public void changeLife(int upLife)
    {
        life += upLife;
        UIManager.instance.setLifeText("Life: " + life);
    }
}
