using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle2_Base : MonoBehaviour
{
    public SCR_scr_Puzzle_2_Item thisItem;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puzzle2"))
        {
            SCR_scr_Puzzle_2_Item objectItem = other.GetComponent<SCR_puz_Puzzle2_Item>().thisItem;
            if (objectItem)
            {
                if(objectItem == thisItem && objectItem.canBeMoved)
                {
                    objectItem.correctPlace = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Puzzle2"))
        {
            SCR_scr_Puzzle_2_Item objectItem = other.GetComponent<SCR_puz_Puzzle2_Item>().thisItem;
            if (objectItem)
            {
                if (objectItem == thisItem && objectItem.canBeMoved)
                {
                    objectItem.correctPlace = false;
                }
            }
        }
    }
}
