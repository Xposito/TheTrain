using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle3_Controller_2_Trigger : MonoBehaviour
{
    public SCR_puz_Puzzle3_Controller_2 controller;
    public bool enemy;
    public bool win;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemy)
            {
                controller.KillPlayer();
            }

            if (win)
            {
                controller.Win();
            }
        }
    }
}
