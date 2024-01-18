using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SCR_puz_Puzzle2_Base : MonoBehaviour
{
    public SCR_scr_Puzzle_2_Item thisItem;

    SCR_Event_Level1 event_Level1;

    private void Start()
    {
        event_Level1 = GameObject.FindGameObjectWithTag("Manager").GetComponent<SCR_Event_Level1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle2"))
        {
            GameObject objectTransform = other.gameObject;
            SCR_scr_Puzzle_2_Item objectItem = other.GetComponent<SCR_puz_Puzzle2_Item>().thisItem;
            if (objectItem)
            {
                if(objectItem == thisItem && objectItem.canBeMoved)
                {
                    objectItem.correctPlace = true;

                    objectTransform.transform.position = transform.position;
                    objectTransform.transform.rotation = transform.rotation;
                    objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                    objectTransform.GetComponent<BoxCollider>().isTrigger = true;

                    if(event_Level1 != null)
                    {
                        event_Level1.CambioDeEstado();
                    }
                    
                }
            }
        }
    }

    
}
