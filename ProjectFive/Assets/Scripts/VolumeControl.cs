using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("MusicVolume").Equals(null))
            audioSource.volume = .5f;
        else
            audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");  
    }
   
    public void SetGameVolumeLevel()
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }

    private void Update()
    {
        VolumeLevel();  
    }

    public void VolumeLevel()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
