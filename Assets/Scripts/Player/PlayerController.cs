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
    [SerializeField] private float FlySpeed = 1f;
    [SerializeField] private float FallSpeed = 1f;
    [SerializeField] private float RunSpeed = 4f;
    [SerializeField] private GameObject Thrust;

    [Header("Multiplier")]
    [SerializeField] private float multiplierForce = 5f;
    [SerializeField] private float multiplierTime = 0.5f;

    [Header("Reducer")]
    [SerializeField] private float reducedSpeed = 1f;
    [SerializeField] private float reducedTime = 0.5f;
    private float RestoreSpeed;

    private bool isPlayerDashing;
    private bool OnMultiplier;
    private bool OnReducer;

    private CameraMove cameraMove;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        playerControls.Player.Dash.performed += ctx => OnButtonPressed();
        playerControls.Player.Dash.canceled += ctx => OnButtonReleased();

        RestoreSpeed = runSpeed;
    }

    private void Start()
    {
        Thrust.gameObject.SetActive(false);

        cameraMove = FindObjectOfType<CameraMove>();
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
        //rb.velocity = new Vector2(rb.velocity.x, FlySpeed);
        rb.gravityScale = -FlySpeed;
        Thrust.gameObject.SetActive(true);
        /*
        currentFlySpeed += flySpeedRate;
        
        currentFlySpeed = Mathf.Clamp(currentFlySpeed, 0f, maxFlySpeed);
        Debug.Log(currentFlySpeed);
        */
    }

    private void OnButtonReleased()
    {
        isPlayerDashing = false;
        //rb.velocity += new Vector2(0, -FallSpeed * Time.deltaTime);
        rb.gravityScale = FallSpeed;
        Thrust.gameObject.SetActive(false);
        
    }

    private void RunCountinous()
    {
        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Multiplier>())
        {
            //transform.position += new Vector3(MultiplierForce, 0, 0);
            StartCoroutine(MultilierForward());
            Debug.Log("Yayayayayayayaya");
        }

        if(other.GetComponent<Reducer>())
        {
            //transform.position += new Vector3(-MultiplierForce, 0, 0);
            StartCoroutine(SpeedReducer());
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Spikes>())
        {
            PlayerDeath();
            
        }
    }
    private IEnumerator MultilierForward()
    {

        OnMultiplier = true;
        Vector3 startPosition = transform.position;

        Vector3 targetPosition = startPosition + new Vector3(multiplierForce, 0, 0);

        float elapsedTime = 0f;

        while (elapsedTime < multiplierTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / multiplierTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        OnMultiplier = false;
    }

    private IEnumerator SpeedReducer()
    {
        OnReducer = true;

        runSpeed = reducedSpeed;
        Debug.Log("Speed is Reduced");

        yield return new WaitForSeconds(reducedTime);

        runSpeed = RestoreSpeed;
        Debug.Log("Speed is Restored");

        OnReducer = false;
    }

    private void PlayerDeath()
    {
        //CameraMove cameraMove = GetComponent<CameraMove>();
        cameraMove.StopCamera();
        Destroy(gameObject);
        Debug.Log("Player is Dead");

    }
}
