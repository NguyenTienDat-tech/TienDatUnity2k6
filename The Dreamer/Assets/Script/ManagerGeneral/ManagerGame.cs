using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance;
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
        LoadGame(1, 1);
    }

    private void LoadGame(int World, int Stage)
    {
        this.World = World;
        this.Stage = Stage;

        SceneManager.LoadScene($"{World}-{Stage}");
    }

    public void ResetGame()
    {
        LoadGame(World, Stage);
    }

    public void NextLever()
    {
        LoadGame(World, Stage + 1);
    }
}
