using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.UIElements.ToolbarMenu;

public class SCR_cam_takePhoto : MonoBehaviour
{


    //Variables  del Raycast
    //[Header("Variables Raycast")]
    //bool m_Started;
    //public LayerMask m_LayerMask;
    //[SerializeField] float m_scale = 1;
    //[SerializeField] float m_long = 1;
    //[SerializeField] float m_distance = 1;

    //Variables para las fotos
    //[Header("Variables Fotos")]
    //[SerializeField] private Renderer[] renderCubo;

    Camera cameraMain;
    Plane[] cameraFrustum;
    public GameObject[] gameObjects;
    public Collider[] collidersProps;
    //Bounds[] collidersBounds;
    //Bounds bound;
    
    public int layer;


    public SCR_scr_Player_Options playerOption;

    [SerializeField] private Renderer[] renderCubo;
    public int elementos = 0;
    public bool itsPhoto = false;
    public Animator animator;


    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        //m_Started = true;
        cameraMain = GetComponent<Camera>();
        gameObjects = GameObject.FindGameObjectsWithTag("Prop");

        collidersProps = new BoxCollider[gameObjects.Length];
        //collidersBounds = new Bounds[gameObjects.Length];

        //for(int i = 0; i < gameObjects.Length; i++)
        //{
        //    collidersProps[i] = gameObjects[i].GetComponent<Collider>();
            //collidersBounds[i] = collidersProps[i].bounds;

        //}

    }

    void Update()
    {
        
        if (playerOption.usingCam == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7, layer))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.name == gameObjects[0].transform.name && Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Funciona");
                    animator.SetBool("AbrirPuerta", true);
                    StartCoroutine(RecordFrame());
                }
            }

            //for(int i = 0; i < gameObjects.Length; i++)
            //{

                //    bound = collidersProps[i].bounds;

                //    cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cameraMain);
                //    if (GeometryUtility.TestPlanesAABB(cameraFrustum, bound))
                //    {

                //        Debug.Log("detecto cubo");
                //        itsPhoto = true;

                //    }
                //    else
                //    {
                //        itsPhoto = false;
                //    }
                //}
                //if (itsPhoto)
                //{

                //    if (Input.GetMouseButtonDown(0))
                //    {

                //        StartCoroutine(RecordFrame());

                //    }
                //}


        }
        //MyCollisions();
        
    }
    

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();

        renderCubo[elementos].material.mainTexture = texture;
  
        elementos++;

        // do something with texture

        //// cleanup
        //Object.Destroy(texture);
    }
}
