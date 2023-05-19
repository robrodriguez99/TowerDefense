using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource _audioSource;
    private const string _volumeKey = "Volume";

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

        _audioSource = GetComponent<AudioSource>();

        // Retrieve volume from PlayerPrefs or set a default value
        float volume = PlayerPrefs.GetFloat(_volumeKey, 0.5f);

        if (_audioSource != null)
        {
            _audioSource.volume = volume;
        }
    }

    public void SetVolume(float vol)
    {
        // Set and save the volume
        if (_audioSource != null)
        {
            _audioSource.volume = vol;
            PlayerPrefs.SetFloat(_volumeKey, vol);
            PlayerPrefs.Save();
        }
    }
}
