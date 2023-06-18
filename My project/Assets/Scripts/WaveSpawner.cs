using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public Transform normalEnemyPrefab;
    public Transform speedyEnemyPrefab;
    public Transform bigEnemyPrefab;

    public Transform spawnPoint;

    public static WaveSpawner Instance;

    public TextMeshProUGUI  waveCountdownText;

    private int _waveCounter = 1;

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
            if (_waveCounter != 0) EventManager.instance.ActionWaveCleared();
            StartCoroutine(SpawnWave());
        }

        GameObject.FindGameObjectsWithTag("Enemy");


        waveCountdownText.text = Mathf.Round(_waveCounter).ToString();
    }

    IEnumerator SpawnWave ()
    {

        for (int i = 0; i < _waveCounter; i++)
        {
            if (i == _waveCounter - 1 && _waveCounter > 2)
                SpawnEnemy(bigEnemyPrefab);
            else
            {
                if(Random.Range(0f,1f) > .4 && _waveCounter > 1)
                    SpawnEnemy(speedyEnemyPrefab);
                else
                    SpawnEnemy(normalEnemyPrefab);
            }
            yield return new WaitForSeconds(1.5f);
        }
        _waveCounter++;

    }

    Transform SpawnEnemy (Transform prefab)
    {
        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint is null in WaveSpawner");
            return null;
        }
        return Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }

}
