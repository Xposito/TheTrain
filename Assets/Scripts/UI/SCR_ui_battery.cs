using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_ui_battery : MonoBehaviour
{

    public Slider slider;
    public SCR_scr_Player_Options player_Options;

    private void Update()
    {
        slider.value = player_Options.timer;
    }
}
