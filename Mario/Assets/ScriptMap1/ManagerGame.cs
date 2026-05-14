using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }
    public int World;
    public int Stage;

    

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnDestroy()
    {
        Instance = null;
    }

    public void NewGame()
    {
        LoadScene(1, 1);
    }

    public void LoadScene(int World, int Stage)
    {
        this.World = World;
        this.Stage = Stage;
        SceneManager.LoadScene($"{World}-{Stage}");
    }

    public void ResetLever()
    {
        LoadScene(World, Stage);
    }

    public void NextLever()
    {
        LoadScene(World, Stage + 1);
    }
}
