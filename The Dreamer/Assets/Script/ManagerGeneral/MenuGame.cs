using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField] GameObject PauseGame;

    [SerializeField] GameObject button;
    [SerializeField] GameObject audioSlide;

    [SerializeField] LoadingGame loadingGame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseGame.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseGame.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }

        PauseGame.SetActive(false);
    }

    public void StartGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }

        Time.timeScale = 1;

        loadingGame.LoadGameScene("1-1");
    }

    public void Options()
    {
        button.SetActive(false);
        audioSlide.SetActive(true);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }
    }

    public void Back()
    {
        button.SetActive(true);
        audioSlide.SetActive(false);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }
    }


    public void Menu()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }

        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }


    public void QuitGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.buttonClip);
        }
        Application.Quit();
    }
}