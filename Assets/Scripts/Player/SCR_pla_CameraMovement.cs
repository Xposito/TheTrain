using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SCR_pla_CameraMovement : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;

    private float sensX; //Sensibilidad en X
    private float sensY; //Sensibilidad en Y

    public Transform body; //Modelo del personaje (cuerpo)

    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        InitializePlayerOptions();

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        body.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void InitializePlayerOptions()
    {
        sensX = playerOptions.sensX;
        sensY = playerOptions.sensY;
    }
}
