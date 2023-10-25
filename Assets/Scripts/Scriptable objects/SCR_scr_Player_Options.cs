using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerOptions", menuName = "ScriptableObjects/PlayerOptions")]
public class SCR_scr_Player_Options : ScriptableObject
{
    #region Opciones de c�mara
    [Header("Cam")]
    public float sensX; //Sensibilidad en X
    public float sensY; //Sensibilidad en Y
    #endregion

    #region Opciones de movimiento

    [Header("Activar / Desactivar")]
    public bool canJump; //Permitir saltar
    public bool canRun; //Permitir correr

    [Header("Movimiento")]
    public float moveSpeed; //Velocidad al andar
    public float sprintSpeed; //Velocidad al correr  
    public float maxStamina; //Estamina m�xima  
    public float staminaToLoose;  //Estamina que se pierde al correr  
    public float staminaToRecover; //Estamina que se recupera al dejar de correr   
    public float groundDrag; //Rozamiento con el suelo

    [Header("Salto")]
    public float jumpForce;  //Fuerza de salto  
    public float jumpCoolDown; //Teimpo entre saltos
    public float airMultiplier; //Velocidad que se a�ade al jugador si est� en el aire

    [Header("Ajustes varios")]
    public LayerMask whatIsGround;  //Capa que se debe detectar como suelo
    public float playerHeight; //Altura del modelo (importante para el ground check)
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
    public KeyCode pickKey; //Tecla para coger cosas
    #endregion

    public bool usingCam;
}
