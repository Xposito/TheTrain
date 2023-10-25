using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_ChangeObject : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public GameObject camOverlay;
    public KeyCode camKey;

    // Start is called before the first frame update
    void Start()
    {
        camOverlay.SetActive(false);
        playerOptions.usingCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(camKey) && playerOptions.usingCam == false)
        {
            playerOptions.usingCam = true;
            camOverlay.SetActive(true);
        }

        else if (Input.GetKeyDown(camKey) && playerOptions.usingCam == true)
        {
            playerOptions.usingCam = false;
            camOverlay.SetActive(false);
        }
    }
}
