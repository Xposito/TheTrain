using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SCR_ui_loading_Screen : MonoBehaviour
{
    public float timeToStop;
    public float timeToStopFade;
    private float timer;
    public RawImage image;
    private float timer2;


   
    void Start()
    {
        timer = timeToStop;
        timer2 = timeToStopFade;

    }


    void Update()
    {
        timer -= 1 * Time.deltaTime;
        
        if (timer <= 0)
        {
            //image.color = Color.Lerp()
            image.color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(1f, 1f, 1f, Mathf.PingPong(Time.time, 1)), timeToStopFade);
            timer2 -= 1 * Time.deltaTime; 
            if(timer2 <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
