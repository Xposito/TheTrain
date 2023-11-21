using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_ChangeObject : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public GameObject camOverlay;
    public Transform cam;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        camOverlay.SetActive(false);
        playerOptions.usingCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerOptions.camKey) && playerOptions.usingCam == false)
        {
            playerOptions.usingCam = true;
            camOverlay.SetActive(true);
        }

        else if (Input.GetKeyDown(playerOptions.camKey) && playerOptions.usingCam == true)
        {
            playerOptions.usingCam = false;
            camOverlay.SetActive(false);
        }

        if (playerOptions.usingCam == true)
        {
            Puzzle2Interact();
        }
    }

    

    void Puzzle2Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layer))
        {
            SCR_scr_Puzzle_2_Item item = hit.transform.GetComponent<SCR_puz_Puzzle2_Item>().thisItem;
            if (item)
            {
                item.canBeMoved = true;
            }
        }
    }
}
