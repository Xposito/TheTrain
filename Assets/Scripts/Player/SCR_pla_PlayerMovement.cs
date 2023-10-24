using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SCR_pla_PlayerMovement : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    
    #region Opciones del jugador

    [Header("Movimiento")]
    private float moveSpeed; //Velocidad al andar
    private float sprintSpeed; //Velocidad al correr  
    private float maxStamina; //Estamina máxima  
    private float staminaToLoose;  //Estamina que se pierde al correr  
    private float staminaToRecover; //Estamina que se recupera al dejar de correr   
    private float groundDrag; //Rozamiento con el suelo

    private float speed; //Velocidad actual del player
    private float stamina; //Estamina actual del player


    [Header("Salto")]
    private float jumpForce;  //Fuerza de salto  
    private float jumpCoolDown; //Teimpo entre saltos
    private float airMultiplier; //Velocidad que se añade al jugador si está en el aire
    private bool readyToJump;


    [Header("Ajustes varios")]
    private LayerMask whatIsGround;  //Capa que se debe detectar como suelo
    private float playerHeight = 2; //Altura del modelo (importante para el ground check)
    public bool canJump;
    public bool canRun;

    [Header("Binds")]
    private KeyCode jumpKey = KeyCode.Space; //Tecla para saltar
    private KeyCode sprintKey = KeyCode.LeftShift; //Tecla para correr

    private Transform orientation; //Transform para girar al personaje al girar la cámara (debe ser el body)
    [HideInInspector] public bool grounded;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private bool isRuning;
    private bool resting;

    #endregion


    void Start()
    {
        InitializePlayerOptions();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        speed = moveSpeed;
        stamina = maxStamina;
        readyToJump = true;

        orientation = transform.Find("Body");
    }

    private void Update()
    {
        CheckFloor(); //Check del suelo
        myInput();  //Controla los input del jugador    
        MovePlayer();  //Mueve al personaje  
        speedControl(); //Controla que no se pase de la velocidad establecida   
    }

    #region Coger las opciones del scriptable
    void InitializePlayerOptions()
    {
        moveSpeed = playerOptions.moveSpeed;
        sprintSpeed = playerOptions.sprintSpeed;
        maxStamina = playerOptions.maxStamina;
        staminaToLoose = playerOptions.staminaToLoose;
        staminaToRecover = playerOptions.staminaToRecover;
        groundDrag = playerOptions.groundDrag;

        jumpForce = playerOptions.jumpForce;
        jumpCoolDown = playerOptions.jumpCoolDown;
        airMultiplier = playerOptions.airMultiplier;

        whatIsGround = playerOptions.whatIsGround;
        playerHeight = playerOptions.playerHeight;

        jumpKey = playerOptions.jumpKey;
        sprintKey = playerOptions.sprintKey;

        canJump = playerOptions.canJump;
        canRun = playerOptions.canRun;
    }
    #endregion 


    private void CheckFloor()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }


    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded && canJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown); //Esto es para que salte el personaje de forma automática si mantienes apretado el botón de saltar
        }

        if (Input.GetKeyDown(sprintKey) && grounded && canRun)
        {
            if (rb.velocity != new Vector3(0, 0, 0) && stamina > 0)
            {
                speed = sprintSpeed;
                isRuning = true;
            }
        }

        if (Input.GetKeyUp(sprintKey) || stamina <= 0)
        {
            isRuning = false;
            speed = moveSpeed;
        }
    }


    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 1000 * Time.deltaTime, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 1000 * Time.deltaTime * airMultiplier, ForceMode.Force);
        }


        if (isRuning)
        {
            looseStamina();
        }
        else
        {
            recoverStamina();
        }
    }


    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }


    private void looseStamina() //Perder estamina al correr
    {
        stamina -= staminaToLoose * Time.deltaTime;
        if (stamina <= 0)
        {
            stamina = 0;
        }
    }

    private void recoverStamina() //Recuperar estamina al dejar de correr
    {
        stamina += staminaToLoose * Time.deltaTime;
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }


    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }


    private void ResetJump()
    {
        readyToJump = true;
    } 
}
