using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_pla_Point : MonoBehaviour
{
    public Transform cam;
    public SCR_scr_Player_Options playerOptions;

    [Header("Crosshair")]

    public GameObject crosshair;
    public Vector3 small;
    public Vector3 big;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObject();
    }

    void CheckForObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerOptions.pickupRange))
        {
            SCR_obj_Objects_ obj = hit.transform.GetComponent<SCR_obj_Objects_>();
            SCR_obj_Ladder_script1 ladder = hit.transform.GetComponent<SCR_obj_Ladder_script1>();

            if (obj || ladder)
            {
                crosshair.transform.localScale = big;
            }
            else
            {
                crosshair.transform.localScale = small;
            }
        }
        else
        {
            crosshair.transform.localScale = small;
        }

    }
}
