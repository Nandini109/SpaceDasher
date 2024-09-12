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
    public float FlySpeed = 5f;
    public float FallSpeed = 2f;
    public float RunSpeed = 3f;
    public float MultiplierForce = 2f;
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

        RunCountinous();
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
        rb.velocity = new Vector2(rb.velocity.x, FlySpeed);
    }

    private void OnButtonReleased()
    {
        isPlayerDashing = false;
        rb.velocity += new Vector2(0, -FallSpeed * Time.deltaTime);
    }

    private void RunCountinous()
    {
        rb.velocity = new Vector2(RunSpeed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Multiplier"))
        {
            transform.position += new Vector3(MultiplierForce, 0, 0);
        }

        if(other.CompareTag("Reducer"))
        {
            transform.position += new Vector3(-MultiplierForce, 0, 0);
        }
    }
}
