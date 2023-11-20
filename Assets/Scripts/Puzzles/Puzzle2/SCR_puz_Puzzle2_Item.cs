using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle2_Item : MonoBehaviour
{
    public SCR_scr_Puzzle_2_Item thisItem;

    private void Start()
    {
        thisItem.canBeMoved = false;
        thisItem.correctPlace = false;
    }
}
