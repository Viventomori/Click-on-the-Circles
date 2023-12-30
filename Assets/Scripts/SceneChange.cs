using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingProgressBar;
    [SerializeField] private GameObject offCanvas;

    public void LoadSceneWithLoading()
    {
        StartCoroutine(LoadSceneAsync());
        offCanvas.SetActive(false);
    }
    
    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        
        loadingScreen.SetActive(true);

        while (!asynLoad.isDone)
        {
            float progress = Mathf.Clamp01(asynLoad.progress / 0.9f); //нормалізуємо від 0 до 1
            loadingProgressBar.value = progress;

            yield return null;
        }
    }
}
