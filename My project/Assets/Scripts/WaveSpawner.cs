using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;


    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI  waveCountdownText;

    private int waveIndex = 0;


    void Update ()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (waveIndex != 0) EventManager.instance.ActionWaveCleared();
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        GameObject.FindGameObjectsWithTag("Enemy");

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }

    }

    Transform SpawnEnemy ()
    {
       return Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
