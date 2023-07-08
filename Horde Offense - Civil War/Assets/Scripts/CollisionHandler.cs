using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool isGrounded = false;

    private LifeManager lifeManager;
    private CoinManager coinManager;

    private void Start()
    {
        lifeManager = GetComponent<LifeManager>();
        coinManager = GetComponent<CoinManager>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "SpeedBoost")
        {
            Destroy(other.gameObject);
            Movement movement = GetComponent<Movement>();
            movement.moveSpeed += 2f;
        }

        if (other.gameObject.tag == "Obstacle")
        {
            lifeManager.changeLife(other.gameObject.GetComponent<Obstacle>().getDamage());
        }

        if (other.gameObject.tag == "Coin")
        {
            coinManager.changeCoin(other.gameObject.GetComponent<Coin>().getCoin());
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

        //Debug.Log($"Você encostou em {other.gameObject.tag}");
}
