using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public float jumpSpeed = 100f;

    Rigidbody rb;
    AudioSource audioSource;
    CollisionHandler collisionHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }
    
    private void FixedUpdate()
    {
        gravityFix();
    }


    void JumpPlayer()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && collisionHandler.isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
    
    public float gravityScale = 5;
    void gravityFix()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }
}
