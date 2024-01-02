using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_ChangeObject : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public GameObject camOverlay;
    public Transform cam;
    public LayerMask layer;

    private bool camIsOff;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        camIsOff = true;
        playerOptions.timer = playerOptions.camTimeOff;
        camOverlay.SetActive(false);
        playerOptions.usingCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerOptions.camKey) && playerOptions.usingCam == false && camIsOff && playerOptions.timer >= playerOptions.camTimeOff)
        {
            playerOptions.usingCam = true;
            camOverlay.SetActive(true);
            camIsOff = false;
            playerOptions.timer = playerOptions.camTimeOn;
        }

        else if (Input.GetKeyDown(playerOptions.camKey) && playerOptions.usingCam == true && !camIsOff)
        {
            playerOptions.usingCam = false;
            camOverlay.SetActive(false);
            camIsOff = true;
        }

        if (playerOptions.usingCam == true && !camIsOff)
        {
            Puzzle2Interact();
            playerOptions.timer -= 1 * Time.deltaTime;

            if(playerOptions.timer <= 0)
            {
                playerOptions.usingCam = false;
                camOverlay.SetActive(false);
                camIsOff = true;
            }
        }

        if(camIsOff)
        {
            playerOptions.timer += 1 * Time.deltaTime;
            if(playerOptions.timer >= playerOptions.camTimeOff)
            {
                playerOptions.timer = playerOptions.camTimeOff;
            }
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
