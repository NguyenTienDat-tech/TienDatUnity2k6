using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPause : MonoBehaviour
{
    public GameObject PauseGame;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                PauseGame.SetActive(true);
            }
            else 
            {
                Time.timeScale = 1f;
                PauseGame.SetActive(false);
            }
        }

    }
}
