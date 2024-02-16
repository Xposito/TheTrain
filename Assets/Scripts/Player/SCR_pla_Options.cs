using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class SCR_pla_Options : MonoBehaviour
{
    public AudioMixer mixer;
    public SCR_scr_Player_Options playerOptions;
    public Slider slider;
    public Slider volumeSlider;
    public TextMeshProUGUI sensText;
    public TextMeshProUGUI volText;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = playerOptions.sensX;
        sensText.text = slider.value.ToString();

        volumeSlider.value = playerOptions.volume;
        volText.text = volumeSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSens();
        ChangeVol();
    }

    public void ChangeSens()
    {
        playerOptions.sensX = slider.value;
        playerOptions.sensY = slider.value;
        sensText.text = slider.value.ToString();
    }

    public void ChangeVol()
    {
        playerOptions.volume = volumeSlider.value;
        
        volText.text = volumeSlider.value.ToString();
    }

    public void SetSound(float soundLevel)
    {
        mixer.SetFloat("musicVol", soundLevel);
    }

    public void ChangeFullScreen(bool fullscreen)
    {
        if (fullscreen) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
