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
    [SerializeField] private float FlySpeed = 5f;
    [SerializeField] private float FallSpeed = 2f;
    [SerializeField] private float RunSpeed = 4f;
    [SerializeField] private GameObject Thrust;

    [Header("Multiplier")]
    [SerializeField] private float MultiplierForce = 5f;
    [SerializeField] private float MultiplierTime = 0.5f;

    [Header("Reducer")]
    [SerializeField] private float ReducedSpeed = 1f;
    [SerializeField] private float ReducedTime = 0.5f;
    private float RestoreSpeed;

    private bool isPlayerDashing;
    private bool OnMultiplier;
    private bool OnReducer;

    private CameraMove cameraMove;
    private AudioManager audioManager;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        audioManager = GameObject.FindObjectOfType<AudioManager>();

        playerControls.Player.Dash.performed += ctx => OnButtonPressed();
        playerControls.Player.Dash.canceled += ctx => OnButtonReleased();

        RestoreSpeed = RunSpeed;
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
        //player velocity is changed to fly speed when we press space
        isPlayerDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, FlySpeed);

        //thrust animation plays
        Thrust.gameObject.SetActive(true);
       
    }

    private void OnButtonReleased()
    {
        //makes player fall down at fall speed
        isPlayerDashing = false;
        rb.velocity += new Vector2(0, -FallSpeed * Time.deltaTime);

        //thrust animation is turned off
        Thrust.gameObject.SetActive(false);
        
    }

    private void RunCountinous()
    {
        //makes player move at constant speed
        rb.velocity = new Vector2(RunSpeed, rb.velocity.y);
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Multiplier>())
        {
            //Execute multiplier coroutine
            StartCoroutine(MultilierForward());

            //audio
            audioManager.PlaySFX(audioManager.speedBoost, 5);
        }

        if(other.GetComponent<Reducer>())
        {
            //Execute reducer coroutine
            StartCoroutine(SpeedReducer());

            //audio
            audioManager.PlaySFX(audioManager.speedSlow, 5);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Spikes>())
        {
            //if player collides with any gameobject with spike script they die
            PlayerDeath();
            audioManager.PlaySFX(audioManager.die, 5);

        }
    }
    private IEnumerator MultilierForward()
    {
        //this makes the multiplier boost smooth 

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
        // on speed reducer it slow down the player for some time
        OnReducer = true;

        RunSpeed = ReducedSpeed;

        yield return new WaitForSeconds(ReducedTime);

        RunSpeed = RestoreSpeed;
     
        OnReducer = false;
    }

    private void PlayerDeath()
    {
        //as soon as the player dies stop camera script will be excecuted 
        cameraMove.StopCamera();

        //Die UI
        MenuManager.Instance.ShowDieMenu();

        //Player object is turned off
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        

    }
}
