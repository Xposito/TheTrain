using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle3_Base : MonoBehaviour
{
    private SCR_puz_Puzzle3_Controller controller;

    private void Start()
    {
        controller = GameObject.Find("Puzzle3Controller").GetComponent< SCR_puz_Puzzle3_Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzleComida"))
        {
            SCR_puz_Puzzle3_Item item = other.GetComponent<SCR_puz_Puzzle3_Item>();
            if(item.itemNumber == controller.counter && item.used == false)
            {
                controller.counter++;
                item.col.isTrigger = true;
                item.rb.isKinematic = true;
                item.used = true;
                item.gameObject.SetActive(false);
            }
            else if(item.itemNumber != controller.counter && item.used == false)
            {
                controller.counter++;
                controller.oneIsWrong = true;
                item.col.isTrigger = true;
                item.rb.isKinematic = true;
                item.used = true;
                item.gameObject.SetActive(false);
            }
        }
    }
}
