using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
