using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private const string _VolumeKey = "Volume";
    private Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        // Initialize the slider value
        _slider.value = PlayerPrefs.GetFloat(_VolumeKey, 0.5f);
    }

    public void OnValueChanged()
    {
        // Update the volume in PlayerPrefs when the slider value is changed
        PlayerPrefs.SetFloat(_VolumeKey, _slider.value);
        PlayerPrefs.Save();
        
        // If there's a MusicManager in the scene, also update the volume directly
        if (MusicManager.instance != null)
        {
            MusicManager.instance.SetVolume(_slider.value);
        }
    }
}
