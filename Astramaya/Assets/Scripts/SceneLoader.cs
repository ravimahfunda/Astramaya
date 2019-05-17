using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider loadingBar;

    public void AddScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void RemoveScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToSceneAsync(string sceneName) {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName) {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!op.isDone) {
            float progress = Mathf.Clamp01(op.progress / .9f);

            loadingBar.value = progress;

            yield return null;
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
