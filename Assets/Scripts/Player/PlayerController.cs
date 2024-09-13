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

    [Header("Player")]
    public float FlySpeed = 5f;
    public float FallSpeed = 2f;
    public float RunSpeed = 4f;

    [Header("Multiplier")]
    public float MultiplierForce = 5f;
    public float MultiplierTime = 0.5f;

    [Header("Reducer")]
    public float ReducedSpeed = 1f;
    public float ReducedTime = 0.5f;
    private float RestoreSpeed;

    private bool isPlayerDashing;
    private bool OnMultiplier;
    private bool OnReducer;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        playerControls.Player.Dash.performed += ctx => OnButtonPressed();
        playerControls.Player.Dash.canceled += ctx => OnButtonReleased();

        RestoreSpeed = RunSpeed;
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
            //transform.position += new Vector3(MultiplierForce, 0, 0);
            StartCoroutine(MultilierForward());
        }

        if(other.CompareTag("Reducer"))
        {
            //transform.position += new Vector3(-MultiplierForce, 0, 0);
            StartCoroutine(SpeedReducer());
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spikes")
        {
            Destroy(gameObject);
            Debug.Log("Player is Dead");
        }
    }
    private IEnumerator MultilierForward()
    {

        OnMultiplier = true;
        Vector3 startPosition = transform.position;

        Vector3 targetPosition = startPosition + new Vector3(MultiplierForce, 0, 0);

        float elapsedTime = 0f;

        while (elapsedTime < MultiplierTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / MultiplierTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        OnMultiplier = false;
    }

    private IEnumerator SpeedReducer()
    {
        OnReducer = true;

        RunSpeed = ReducedSpeed;
        Debug.Log("Speed is Reduced");

        yield return new WaitForSeconds(ReducedTime);

        RunSpeed = RestoreSpeed;
        Debug.Log("Speed is Restored");

        OnReducer = false;
    }
}
