using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider SFXslider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("bgvolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("Background", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("bgvolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxvolume", volume);
    }

    private void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("bgvolume");
        SFXslider.value = PlayerPrefs.GetFloat("sfxvolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
