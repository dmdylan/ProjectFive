using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMusicVolume : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SetTheVolumeSetting();
    }

    private float SetTheVolumeSetting()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        return musicVolume;
    }
}
