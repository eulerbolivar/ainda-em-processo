using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool isGrounded = false;

    void OnCollisionEnter(Collision other) 
    {
            if (other.gameObject.tag == "SpeedBoost")
            {
                Destroy(other.gameObject);
                Movement movement = GetComponent<Movement>();
                movement.moveSpeed += 2f;
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
