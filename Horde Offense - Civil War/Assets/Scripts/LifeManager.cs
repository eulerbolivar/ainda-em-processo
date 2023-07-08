using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int life;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLife(int upLife)
    {
        life += upLife;
        UIManager.instance.setLifeText("Life: " + life);
    }
}
