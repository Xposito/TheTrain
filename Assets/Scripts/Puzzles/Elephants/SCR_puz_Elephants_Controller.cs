using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_puz_Elephants_Controller : MonoBehaviour
{
    public SCR_scr_Elephants elephantsSO;

    //public bool elephant1;
    //public bool elephant2;
    //public bool elephant3;

    //Img elefantes sin cinseguir
    public Image elephant1base;
    public Image elephant2base;
    public Image elephant3base;

    //Img elefantes conseguidos
    public Sprite elephant1white;
    public Sprite elephant2white;
    public Sprite elephant3white;

    public Sprite elephant1img;
    public Sprite elephant2img;
    public Sprite elephant3img;

    //public int elephantNumber;
    public TextMeshProUGUI elephantText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        elephantText.text = elephantsSO.elephantNumber.ToString() + "/3 ELEPHANTS";

        if (elephantsSO.elephant1)
        {
            elephant1base.sprite = elephant1img;
        }
        else
        {
            elephant1base.sprite = elephant1white;
        }

        if (elephantsSO.elephant2)
        {
            elephant2base.sprite = elephant2img;
        }
        else
        {
            elephant2base.sprite = elephant2white;
        }

        if (elephantsSO.elephant3)
        {
            elephant3base.sprite = elephant3img;
        }
        else
        {
            elephant3base.sprite = elephant3white;
        }
    }
}
