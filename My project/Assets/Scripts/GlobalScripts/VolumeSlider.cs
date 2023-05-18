using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private const string VolumeKey = "Volume";
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        // Initialize the slider value
        slider.value = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
    }

    public void OnValueChanged()
    {
        // Update the volume in PlayerPrefs when the slider value is changed
        PlayerPrefs.SetFloat(VolumeKey, slider.value);
        PlayerPrefs.Save();
        
        // If there's a MusicManager in the scene, also update the volume directly
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(slider.value);
        }
    }
}
