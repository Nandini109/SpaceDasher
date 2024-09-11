using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction Dash;

    private Rigidbody2D rb;
    public float Fly = 5f;
    public float Fall = 2f;
    private bool isPlayerDashing;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        playerControls.Player.Dash.performed += ctx => OnButtonPressed();
        playerControls.Player.Dash.canceled += ctx => OnButtonReleased();
    } 

    private void Update()
    {
        if (isPlayerDashing)
        {
            OnButtonPressed();
        }
        else
        {
            OnButtonReleased();
        }
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnButtonPressed()
    {
        isPlayerDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, Fly);
    }

    private void OnButtonReleased()
    {
        isPlayerDashing = false;
        rb.velocity += new Vector2(0, -Fall * Time.deltaTime);
    }

}
