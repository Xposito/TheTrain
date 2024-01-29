using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_puz_Puzzle3_Controller : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject component1;
    public GameObject component2;
    public GameObject component3;
    public GameObject component4;

    [Header("Comida")]
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;

    [Header("Transforms")]
    public Transform component1Transform;
    public Transform component2Transform;
    public Transform component3Transform;
    public Transform component4Transform;

    [Header("Bools")]
    public bool oneIsWrong;
    public bool puzzleComplete;

    [Header("Counter")]
    public int counter;

    [Header("Scripts objetos")]
    private SCR_puz_Puzzle3_Item component1Scr;
    private SCR_puz_Puzzle3_Item component2Scr;
    private SCR_puz_Puzzle3_Item component3Scr;
    private SCR_puz_Puzzle3_Item component4Scr;

    public SCR_pla_Pick_Objects pickObjects;


    void Start()
    {
        //Get the scripts
        component1Scr = component1.GetComponent<SCR_puz_Puzzle3_Item>();
        component2Scr = component2.GetComponent<SCR_puz_Puzzle3_Item>();
        component3Scr = component3.GetComponent<SCR_puz_Puzzle3_Item>();
        component4Scr = component4.GetComponent<SCR_puz_Puzzle3_Item>();

        food1.SetActive(false);
        food2.SetActive(false);
        food3.SetActive(false);
        food4.SetActive(false);

        pickObjects = GameObject.Find("CameraHolder").GetComponentInChildren<SCR_pla_Pick_Objects>();

        counter = 0;
    }

    void Update()
    {
        ActivateFood();
        CheckPuzzle();
    }


    #region Check puzzle state
    void CheckPuzzle()
    {
        if (counter == 4 && !oneIsWrong)
        {
            puzzleComplete = true;
            Debug.Log("Has ganado :)");
        }

        else if (counter == 4 && oneIsWrong)
        {
            ResetPuzzle();
        }
    }
    #endregion

    #region Reset puzzle
    void ResetPuzzle()
    {
        //Move components to their previous position
        component1.transform.position = component1Transform.position;
        component2.transform.position = component2Transform.position;
        component3.transform.position = component3Transform.position;
        component4.transform.position = component4Transform.position;

        //Make components trigger
        component1Scr.col.isTrigger = false;
        component2Scr.col.isTrigger = false;
        component3Scr.col.isTrigger = false;
        component4Scr.col.isTrigger = false;

        //Make components be affected by phisics
        component1Scr.rb.isKinematic = false;
        component2Scr.rb.isKinematic = false;
        component3Scr.rb.isKinematic = false;
        component4Scr.rb.isKinematic = false;

        //Make components unused
        component1Scr.used = false;
        component2Scr.used = false;
        component3Scr.used = false;
        component4Scr.used = false;

        //Make components visible
        component1Scr.gameObject.SetActive(true);
        component2Scr.gameObject.SetActive(true);
        component3Scr.gameObject.SetActive(true);
        component4Scr.gameObject.SetActive(true);

        //Make food invisible
        food1.SetActive(false);
        food2.SetActive(false);
        food3.SetActive(false);
        food4.SetActive(false);

        oneIsWrong = false;
        puzzleComplete = false;
        counter = 0;

        pickObjects.DropObject();
        Debug.Log("Lo has hecho mal");
    }
    #endregion

    #region Food visible part
    void ActivateFood()
    {
        if (counter == 1)
        {
            food1.SetActive(true);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(false);
        }

        if (counter == 2)
        {
            food1.SetActive(false);
            food2.SetActive(true);
            food3.SetActive(false);
            food4.SetActive(false);
        }

        if (counter == 3)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(true);
            food4.SetActive(false);
        }

        if (counter == 4)
        {
            food1.SetActive(false);
            food2.SetActive(false);
            food3.SetActive(false);
            food4.SetActive(true);
        }
    }
    #endregion
}
