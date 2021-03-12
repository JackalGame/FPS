using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Slider slider;

    int currentScene;
    float sliderProgress;

    private void Awake()
    {
        sliderProgress = 1;
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously ()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(currentScene + 1);

        while (!loadLevel.isDone)
        {
            float progress = Mathf.Clamp01(loadLevel.progress / 0.9f);
            sliderProgress -= progress;
            slider.value = sliderProgress;
            yield return null;
        }
    }
}
