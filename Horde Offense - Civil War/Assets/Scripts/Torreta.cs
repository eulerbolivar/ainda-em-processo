using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float waitTimer;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootTimer;
    [SerializeField] private float betweenShotsTime;
    [SerializeField] private float betweenShotsTimer;
    [SerializeField] private float destroyShotTime;
    [SerializeField] private bool canShoot;
    [SerializeField] private GameObject shootObject;
    [SerializeField] private Transform spawnPos;

    void Start()
    {
        waitTimer = 0;
        shootTimer = 0;
        betweenShotsTimer = 0;
    }

    void Update()
    {
        if (!canShoot)
        {
            waitTimer += Time.deltaTime;
        }
        else
        {
            shootTimer += Time.deltaTime;
            betweenShotsTimer += Time.deltaTime;
        }
        
        if(waitTimer >= waitTime)
        {
            canShoot = true;
            waitTimer = 0;
        }

        if (shootTimer >= shootTime)
        {
            canShoot = false;
            shootTimer = 0;
        }

        if(betweenShotsTimer >= betweenShotsTime)
        {
            betweenShotsTimer = 0;
            spawn();
        }
    }

    void spawn()
    {
        GameObject shot = Instantiate(shootObject);
        shot.transform.position = spawnPos.position;
        Destroy(shot, destroyShotTime);
    }
}
