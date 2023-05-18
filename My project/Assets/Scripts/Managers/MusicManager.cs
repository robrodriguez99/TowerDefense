using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource audioSource;
    private const string VolumeKey = "Volume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Retrieve volume from PlayerPrefs or set a default value
        float volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);

        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void SetVolume(float vol)
    {
        // Set and save the volume
        if (audioSource != null)
        {
            audioSource.volume = vol;
            PlayerPrefs.SetFloat(VolumeKey, vol);
            PlayerPrefs.Save();
        }
    }
}
