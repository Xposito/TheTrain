using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using static UnityEditor.Progress;

public class SCR_pla_PlayerMovement : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    
    #region Opciones del jugador

    [Header("Movimiento")]
    private float moveSpeed; //Velocidad al andar
    private float sprintSpeed; //Velocidad al correr  
    private float crouchSpeed; //Velocidad al agacharse
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
    public bool canCrouch;


    [Header("Binds")]
    private KeyCode jumpKey = KeyCode.Space; //Tecla para saltar
    private KeyCode sprintKey = KeyCode.LeftShift; //Tecla para correr
    private KeyCode crouchKey; //Tecla para correr

    private Transform orientation; //Transform para girar al personaje al girar la cámara (debe ser el body)
    [HideInInspector] public bool grounded;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private bool isRuning;
    private bool isCrouching;
    private bool resting;

    #endregion

    public GameObject body;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isCrouching = false;
        speed = moveSpeed;
        stamina = maxStamina;
        readyToJump = true;

        orientation = transform.Find("Body");
    }

    private void Update()
    {
        InitializePlayerOptions();
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
        crouchSpeed = playerOptions.crouchSpeed;
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
        crouchKey = playerOptions.crouchKey;

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

        //Saltar
        if (Input.GetKey(jumpKey) && readyToJump && grounded && canJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown); //Esto es para que salte el personaje de forma automática si mantienes apretado el botón de saltar
        }

        //Correr
        if (Input.GetKeyDown(sprintKey) && grounded && canRun && !isCrouching)
        {
            if (rb.velocity != new Vector3(0, 0, 0) && stamina > 0)
            {
                speed = sprintSpeed;
                isRuning = true;
            }
        }

        //Dejar de correr
        if (Input.GetKeyUp(sprintKey) && !isCrouching || stamina <= 0 && !isCrouching)
        {
            isRuning = false;
            speed = moveSpeed;
        }

        //Agacharse
        if (Input.GetKeyDown(crouchKey) && grounded && isCrouching == false && canCrouch)
        {
            body.transform.localScale = new Vector3(body.transform.localScale.x, 1.25f / 2, body.transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            speed = crouchSpeed;
            isCrouching = true;
        }

        //Levantarse
        else if (Input.GetKeyDown(crouchKey) && grounded && isCrouching == true && canCrouch)
        {
            body.transform.localScale = new Vector3(body.transform.localScale.x, 1.25f, body.transform.localScale.z);
            speed = moveSpeed;
            isCrouching = false;
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

    private void LadderSpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > playerOptions.ladderSpeed)
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
