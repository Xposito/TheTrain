using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puzzle_2_Item", menuName = "ScriptableObjects/Puzzles/Puzzle2")]
public class SCR_scr_Puzzle_2_Item : ScriptableObject
{
    public string itemName;
    public bool canBeMoved;
    public bool correctPlace;
}
