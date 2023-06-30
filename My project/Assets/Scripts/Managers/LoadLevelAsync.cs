using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LoadLevelAsync : MonoBehaviour
{
    [SerializeReference] private Image _progressBar;
    [SerializeReference] private TextMeshProUGUI _progressText;
    [SerializeReference] private string _targetScene = UnityScenes.Level1.ToString();


    void Start() {
        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_targetScene);
        float progress = 0f;
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);
            _progressBar.fillAmount = progress;
            _progressText.text = progress * 100f + "%";

            if(operation.progress >= .9f)
            {
                _progressText.text = "Press any key to continue";
                if (Input.anyKeyDown)
                    operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
