using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.UIElements.ToolbarMenu;

public class SCR_cam_takePhoto : MonoBehaviour
{
    [Header("Arrays")]
    public GameObject[] puertas;
    
    public LayerMask layer;
    public SCR_scr_Player_Options playerOption;

    int elementos = 0;
    int puertasInt = 0;
    public Animator animator;

    [Header("UIPhoto")]
    public GameObject flash;
    public GameObject overlay;
    [SerializeField] private Renderer[] renderCubo;

    public Tutorial tutorial;


    void Update()
    {
        
        if (playerOption.usingCam == true)
        {
            UseCamera();
        }
        
        
    }
    

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        overlay.SetActive(false);
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        yield return new WaitForEndOfFrame();
        overlay.SetActive(true);
        flash.SetActive(true);

        renderCubo[elementos].material.mainTexture = texture;
  
        elementos++;

    }
     
    void UseCamera()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7, layer))
        {
            Debug.Log(hit.transform.name);
            if (Input.GetMouseButtonDown(0))
            {
                Collider collider = hit.transform.GetComponent<Collider>();
                collider.enabled = false;
                flash.SetActive(false);
                tutorial.CambioDeEstado();
                StartCoroutine(RecordFrame());
            }
        }
    }
}
