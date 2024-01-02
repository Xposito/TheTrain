using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerOptions", menuName = "ScriptableObjects/PlayerOptions")]
public class SCR_scr_Player_Options : ScriptableObject
{
    #region Opciones de movimiento cámara
    [Header("Cam")]
    public float sensX; //Sensibilidad en X
    public float sensY; //Sensibilidad en Y
    #endregion

    #region Opciones de cámara in-game
    [Header("In-game cam")]
    public float camTimeOn; //Tiempo que la camara puede estar encendida
    public float camTimeOff; //Tiempo que se necesita para volver a encender la camara
    public float timer;
    public bool usingCam;
    #endregion

    #region Opciones de movimiento

    [Header("Activar / Desactivar")]
    public bool canJump; //Permitir saltar
    public bool canRun; //Permitir correr

    [Header("Movimiento")]
    public float moveSpeed; //Velocidad al andar
    public float sprintSpeed; //Velocidad al correr  
    public float crouchSpeed; //Velocidad al agacharse  
    public float ladderSpeed; //Velocidad al subir escaleras
    public float maxStamina; //Estamina máxima  
    public float staminaToLoose;  //Estamina que se pierde al correr  
    public float staminaToRecover; //Estamina que se recupera al dejar de correr   
    public float groundDrag; //Rozamiento con el suelo

    [Header("Salto")]
    public float jumpForce;  //Fuerza de salto  
    public float jumpCoolDown; //Teimpo entre saltos
    public float airMultiplier; //Velocidad que se añade al jugador si está en el aire

    [Header("Ajustes varios")]
    public LayerMask whatIsGround;  //Capa que se debe detectar como suelo
    public float playerHeight; //Altura del modelo (importante para el ground check)
    public float ladderInteractDistance;
    #endregion

    #region Opciones de recoger objetos
    [Header("Recoger objetos")]
    public float pickupRange;
    public float pickupForce;
    #endregion

    #region Teclas
    [Header("Binds")]
    public KeyCode jumpKey; //Tecla para saltar
    public KeyCode sprintKey; //Tecla para correr
    public KeyCode crouchKey; //Tecla para agacharse
    public KeyCode pickKey; //Tecla para coger cosas
    public KeyCode camKey; //Tecla para saltar
    public KeyCode onLadderKey; //Tecla para subir a una escalera
    public KeyCode offLadderKey; //Tecla para bajar de una escalera
    #endregion
}
