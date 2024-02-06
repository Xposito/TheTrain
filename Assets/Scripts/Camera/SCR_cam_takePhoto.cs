using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.UIElements.ToolbarMenu;

public class SCR_cam_takePhoto : MonoBehaviour
{
    
    
    
    public LayerMask layer;
    public SCR_scr_Player_Options playerOption;

    int elementos = 0;
    
    

    [Header("UIPhoto")]
    public GameObject flash;
    public GameObject overlay;
    [SerializeField] private Renderer[] renderCubo;

    public Tutorial tutorial;
    SCR_Event_Level1 eventLevel1;
    SCR_event_Lvl2 eventLevel2;
    

    private void Start()
    {
        eventLevel1 = GameObject.FindGameObjectWithTag("Manager").GetComponent<SCR_Event_Level1>();
        eventLevel2 = GameObject.FindGameObjectWithTag("Manager").GetComponent<SCR_event_Lvl2>();
    }

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
                if(tutorial != null)
                {
                    tutorial.CambioDeEstado();
                }
                else if(eventLevel1 != null)
                {
                    eventLevel1.CambioDeEstado();
                }
                else if(eventLevel2 != null)
                {
                    eventLevel2.CambioDeEstado();
                }
                
                StartCoroutine(RecordFrame());
            }
        }
    }
}
