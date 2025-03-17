using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int currentLevel = 1;
    public int totalLevels = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber >= 1)
        {
            currentLevel = levelNumber;
            SceneManager.LoadScene("level_" + levelNumber);
            Debug.Log("Loading Level " + levelNumber);
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevel < totalLevels)
        {
            currentLevel++;
            LoadLevel(currentLevel);
        }
        else
        {
            Debug.Log("All levels completed");
        }
    }

    public void CompleteLevel()
    {
        LoadNextLevel();
    }
}