using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_obj_Ladder_script1 : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public bool canGoUp;

    private bool onStairs;
    private Rigidbody rb;
    private Transform playerPos;
    private SCR_pla_PlayerMovement player;

    private void Start()
    {
        onStairs = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<SCR_pla_PlayerMovement>();
            if (player)
            {
                playerPos = player.transform.GetComponent<Transform>();
                rb = player.GetComponent<Rigidbody>();
                onStairs = true;
                Debug.Log("Player");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SCR_pla_PlayerMovement playerNetwork = other.GetComponentInParent<SCR_pla_PlayerMovement>();

            if (player)
            {
                notOnStairs();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && onStairs && canGoUp)
        {
            upStairs();
        }


        if (Input.GetKey(playerOptions.offLadderKey) && onStairs)
        {
            notOnStairs();
        }
    }

    void upStairs()
    {
        player.enabled = false;
        
        rb.AddForce(transform.up * playerOptions.ladderSpeed * 1000 * Time.deltaTime, ForceMode.Force);
        //playerPos.position += transform.up * speed * Time.deltaTime;
    }

    void notOnStairs()
    {
        player.enabled = true;
        player = null;
        playerPos = null;
        onStairs = false;
        canGoUp = false;
        rb = null;

    }
}
