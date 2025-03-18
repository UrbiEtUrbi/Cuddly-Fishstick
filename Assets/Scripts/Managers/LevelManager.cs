using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}
    public GameObject[] levelPrefabs;

    private int currentLevel;
    private int totalLevels = 0;

    private GameObject currentLevelInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void LoadLevel(int levelNumber)
    {
        if (levelNumber >= 0 && levelNumber <= totalLevels)
        {
            currentLevel = levelNumber;

            if (currentLevelInstance != null)
            {
                Destroy(currentLevelInstance);
            }

            currentLevelInstance = Instantiate(levelPrefabs[levelNumber]);
            Debug.Log("Loading Level " + levelNumber);
        }
        else
        {
            Debug.LogError("Invalid level number: " + levelNumber);
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevel + 1 == totalLevels)
        {
            GameStateManager.Instance.SetCurrentGameState(GameStates.Win);
        }
        LoadLevel(currentLevel + 1);
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
        if (totalLevels == 0)
        {
            totalLevels = levelPrefabs.Length-1;
        }
    }
}