using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashingPlayerMovmet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dampAmount;
    [SerializeField] private float chengDirDamping;
    [SerializeField] private Slider dashSlider;

    private Rigidbody2D _movementRb;
    private Vector2 moveInput;
    private float curentSpeed;
    private bool isDashing;
    private float dashTimer;

    private void Awake()
    {
        _movementRb = GetComponent<Rigidbody2D>();
        dashTimer = dashTime;
        if (dashSlider != null)
        {
            dashSlider.maxValue = dashTime;
            dashSlider.minValue = 0;
            dashSlider.value = dashTimer;
        }
        
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        isDashing = Input.GetKey(KeyCode.Space);
        if (isDashing && dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            if (dashSlider != null)
                dashSlider.value = dashTimer;
        }
        else if (dashTimer < dashTime)
        {
            dashTimer += Time.deltaTime;
            if (dashSlider != null)
                dashSlider.value = dashTimer;
        }

    }

    private void FixedUpdate()
    {
        if (isDashing && dashTimer >= .1f)
        {
            _movementRb.velocity = transform.up * dashSpeed;
        }
        else
        {
            _movementRb.velocity = moveInput * speed;
        }
        
    }
}
