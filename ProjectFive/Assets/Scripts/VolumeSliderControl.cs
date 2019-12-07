using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Slider slider = GetComponent<Slider>();

        if (PlayerPrefs.GetFloat("MusicVolume").Equals(null))
            slider.value = .5f;
        else
            slider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
}
