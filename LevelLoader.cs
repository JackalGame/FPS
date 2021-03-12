using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            Splash();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void StartGame(float timeToWait)
    {
        StartCoroutine(DelayedTransition(timeToWait));
    }

    public void Splash()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(DelayedTransition(3.5f));
    }

    IEnumerator DelayedTransition(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/jackal_game/");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/JackalGame");
    }

    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/JackalGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
