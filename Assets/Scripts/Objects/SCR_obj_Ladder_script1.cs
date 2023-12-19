using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_obj_Ladder_script1 : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public bool canGoUp;

    private bool onStairs;
    private Rigidbody rb;
    private SCR_pla_PlayerMovement player;
    private float verticalInput;
    private Vector3 moveDirection;

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
                rb = player.GetComponent<Rigidbody>();
                onStairs = true;
                canGoUp = true;
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
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = transform.up * verticalInput;

        

        if (onStairs && canGoUp)
        {
            rb.AddForce(moveDirection.normalized * playerOptions.ladderSpeed * 1000 * Time.deltaTime, ForceMode.Force);
            LadderSpeedControl();
            player.enabled = false;
            rb.useGravity = false;
        }

        if (Input.GetKey(playerOptions.offLadderKey) && onStairs)
        {
            notOnStairs();
        }
    }




    private void LadderSpeedControl()
    {
        Vector3 flatVel = new Vector3(0f, rb.velocity.y, 0f);

        if (flatVel.magnitude > playerOptions.ladderSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * playerOptions.ladderSpeed;
            rb.velocity = new Vector3(rb.velocity.x, limitedVel.y, rb.velocity.z);
        }
    }




    void notOnStairs()
    {
        
        player.enabled = true;
        player = null;
        onStairs = false;
        canGoUp = false;
        rb.useGravity = true;
        rb.AddForce(transform.forward * -1 * 1000 * Time.deltaTime, ForceMode.Impulse);
        rb = null;

    }
}
