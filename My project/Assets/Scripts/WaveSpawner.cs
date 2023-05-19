using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public static WaveSpawner Instance;

    public TextMeshProUGUI  waveCountdownText;

    private int _waveIndex = 0;

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update ()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (_waveIndex != 0) EventManager.instance.ActionWaveCleared();
            StartCoroutine(SpawnWave());
        }

        GameObject.FindGameObjectsWithTag("Enemy");


        waveCountdownText.text = Mathf.Round(_waveIndex).ToString();
    }

    IEnumerator SpawnWave ()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }

    }

    Transform SpawnEnemy ()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint is null in WaveSpawner");
            return null;
        }

        return Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
