using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private Vector2 movement;    
    [SerializeField] private float playerSpeed = 7f;
    [SerializeField] private bool isWalking = false;

    public Vector2 Movement => movement;
    public bool IsWalking => isWalking;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        ProcessPlayerMovement();
    }

    private void ProcessInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        isWalking = (inputX != 0 || inputY != 0);
        if (Mathf.Abs(inputX) > Mathf.Abs(inputY))
        {
            inputY = 0;
        }
        else
        {
            inputX = 0;
        }
        movement = new Vector2(inputX, inputY);
    }

    private void ProcessPlayerMovement()
    {
        if (rb2D && isWalking)
        {
            rb2D.MovePosition(rb2D.position + movement * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
