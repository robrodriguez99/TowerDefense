using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _rotationSpeed = .7f;
    public AudioClip collectSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  // Add an AudioSource if there isn't one already
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _rotationSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            EventManager.instance.ActionRewardEarned(10);
            audioSource.PlayOneShot(collectSound);
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            StartCoroutine(DestroyAfterSound());
        }

    }

    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(collectSound.length); // Wait for the sound to finish
        Destroy(this.gameObject); // Destroy the GameObject after the sound finishes playing
    }
}
