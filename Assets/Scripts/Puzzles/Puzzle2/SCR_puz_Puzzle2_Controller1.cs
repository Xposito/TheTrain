using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle2_Controller1 : MonoBehaviour
{
    public SCR_scr_Puzzle_2_Item item1;
    public SCR_scr_Puzzle_2_Item item2;
    public SCR_scr_Puzzle_2_Item item3;


    void Update()
    {
        if(item1.correctPlace && item2.correctPlace && item3.correctPlace)
        {
            WinPuzzle2();
        }
    }

    void WinPuzzle2()
    {
        Debug.Log("Has terminado este puzzle UwU");
    }
}
