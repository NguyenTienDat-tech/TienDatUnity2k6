using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PauseGame : MonoBehaviour
{
    public GameObject GameHay;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume1()
    {
        Time.timeScale = 1f;
        GameHay.SetActive(false);
    }


}
