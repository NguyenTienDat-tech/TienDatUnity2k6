using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void MenuGame1()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResetStart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
