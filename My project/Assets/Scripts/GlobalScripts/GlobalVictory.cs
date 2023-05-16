using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GlobalVictory : MonoBehaviour
{
    public static GlobalVictory Instance;
    public bool IsVictory { get; set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
