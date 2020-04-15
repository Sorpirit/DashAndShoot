using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _movementRb;
    private Vector2 moveInput;

    private void Awake()
    {
        _movementRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        _movementRb.velocity = moveInput * speed;
    }
}
