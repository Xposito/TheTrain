using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_pla_Pick_Objects : MonoBehaviour
{
    public SCR_scr_Player_Options playerOptions;
    public Transform holdArea;

    #region private values
    private KeyCode pickKey;
    private float pickupRange;
    private float pickupForce;
    private GameObject heldObject;
    private Rigidbody heldObjRB;
    //public float throwForce;
    #endregion 


    private void Start()
    {
        InitializePlayerOptions();
    }

    void Update()
    {
        if (Input.GetKeyDown(pickKey))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }

    }


    void InitializePlayerOptions()
    {
        pickupRange = playerOptions.pickupRange;
        pickupForce = playerOptions.pickupForce;
        pickKey = playerOptions.pickKey;
    }


    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce * Time.deltaTime * 500);
        }
    }


    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 18;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            //heldObjRB.transform.parent = holdArea;
            heldObject = pickObj;
        }
    }

    public void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObject = null;
    }
}
