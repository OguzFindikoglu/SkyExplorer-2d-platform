using UnityEngine;
using UnityEngine.InputSystem;   // yeni Input System

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket")]
    public float moveSpeed = 8f;
    public float jumpForce = 14f;

    [Header("Zemin Kontrol�")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (InfoPanel.IsOpen || DeathScreen.IsDead) { moveInput = 0f; return; }
        // Panel a��ksa hi�bir �ey yapma (z�plama, y�n yok)
        if (InfoPanel.IsOpen)
        {
            moveInput = 0f;
            return;
        }

        var keyboard = Keyboard.current;
        if (keyboard == null) return;   // klavye yoksa ��k

        // Yatay girdi: A/D ya da sol/sa� ok
        moveInput = 0f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveInput = -1f;
        else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveInput = 1f;

        // Zeminde miyiz?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Sadece zemindeyken z�pla (Space tu�u)
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Karaktere y�n ver
        if (moveInput > 0.01f)
            transform.localScale = new Vector3(5, 5, 1);
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 1);
    }

    void FixedUpdate()
    {
        if (InfoPanel.IsOpen || DeathScreen.IsDead) { rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); return; }
        // Panel a��ksa hareket etme
        if (InfoPanel.IsOpen)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}