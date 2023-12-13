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
    public TextMeshProUGUI  remainingWavesText;

    private int _waveCounter = 1;
    private int _enemiesInWave;

    private bool _firstWave = true;
    [SerializeField] public int remainingWaves = 5;


    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update ()
    {
        var enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        waveCountdownText.text = enemiesLeft.ToString();

        if (enemiesLeft == 0)
        {
            if (!EventManager.instance.IsBuildingPhase) {
                StartCoroutine(SpawnWave());
            }
            if (_waveCounter != 0) 
            {            
                if (!_firstWave && EventManager.instance.IsBuildingPhase ) 
                    EventManager.instance.ActionBuildingPhaseStarted();
             
                if(!EventManager.instance.IsBuildingPhase ) {

                    EventManager.instance.ActionWaveCleared();
                    _firstWave = false;
                    remainingWaves--;
                    remainingWavesText.text = remainingWaves.ToString();
                }
                
            }
        }
    }

    IEnumerator SpawnWave ()
    {
        _enemiesInWave = _waveCounter;
        waveCountdownText.text = _enemiesInWave.ToString();

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
