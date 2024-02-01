using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_pla_Pistas : MonoBehaviour
{
    public float timer;

    public GameObject menu;

    [Header("Timers")]
    public float pista1Time;
    public float pista2Time;
    public float pista3Time;

    [Header("Buttons state")]
    public bool button1Ready;
    public bool button2Ready;
    public bool button3Ready;

    [Header("Buttons")]
    public Button button1;
    public Button button2;
    public Button button3;

    [Header("Texts")]
    private TextMeshProUGUI textButton1;
    private TextMeshProUGUI textButton2;
    private TextMeshProUGUI textButton3;

    public Sprite unlockedImage;

    public Image image1;
    public Image image2;
    public Image image3;

    public bool MenuActive;


    void Start()
    {
        MenuActive = false;
        timer = pista1Time;

        textButton1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        textButton2 = button2.GetComponentInChildren<TextMeshProUGUI>();
        textButton3 = button3.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!MenuActive)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }

        timer -= Time.deltaTime;

        if(timer <= 0 && !button1Ready && !button2Ready)
        {
            timer = pista2Time;
            button1Ready = true;
        }

        if (timer <= 0 && button1Ready && !button2Ready)
        {
            timer = pista3Time;
            button2Ready = true;
        }

        if (timer <= 0 && button1Ready && button2Ready)
        {
            button3Ready = true;
        }



        textButton1.text = Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00");



        if (button1Ready)
        {

            textButton2.text = Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00");
        }
        else
        {
            float newtime = timer + pista2Time;
            textButton2.text = Mathf.Floor(newtime / 60).ToString("00") + ":" + Mathf.FloorToInt(newtime % 60).ToString("00");
        }


        if (!button1Ready)
        {
            float newtime3 = timer + pista2Time + pista3Time;
            textButton3.text = Mathf.Floor(newtime3 / 60).ToString("00") + ":" + Mathf.FloorToInt(newtime3 % 60).ToString("00");
        }

        else if (button1Ready && !button2Ready)
        {
            float newtime2 = timer + pista3Time;
            textButton3.text = Mathf.Floor(newtime2 / 60).ToString("00") + ":" + Mathf.FloorToInt(newtime2 % 60).ToString("00");
        }
        else if(button1Ready && button2Ready)
        {
            textButton3.text = Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00");
        }


        if (button1Ready)
        {
            textButton1.text = "";
            image1.sprite = unlockedImage;
        }

        if (button2Ready)
        {
            textButton2.text = "";
            image2.sprite = unlockedImage;
        }

        if (button3Ready)
        {
            textButton3.text = "";
            image3.sprite = unlockedImage;
        }
    }

   public void UnlockPista1()
    {
        if (button1Ready)
        {
            button1.gameObject.SetActive(false);
        }
    }

    public void UnlockPista2()
    {
        if (button2Ready)
        {
            button2.gameObject.SetActive(false);
        }
    }

    public void UnlockPista3()
    {
        if (button3Ready)
        {
            button3.gameObject.SetActive(false);
        }
    }

    void OpenMenu()
    {
        //Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menu.SetActive(true);
        MenuActive = true;
    }

    void CloseMenu()
    {
        //Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.SetActive(false);
        MenuActive = false;
    }


}
