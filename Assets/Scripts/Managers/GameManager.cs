using UnityEngine;

public class GameManager : LocalManager
{
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
    }
    public override void Init()
    {
        base.Init();
        
        if (CheckForSave())
        {
            StartGame();
        }
        else
        {
            StartFromSave();
        }
    }

    private void StartGame()
    {
        // Sets Gamestate
        GameStateManager.Instance.SetCurrentGameState(GameStates.Playing);
        // Starts the game
        LevelManager.Instance.SetCurrentLevel(-1);
        LevelManager.Instance.LoadNextLevel();
        PlayerManager.Instance.SpawnPlayer(0);
        UIManager.Instance.Init();
    }

    private void StartFromSave()
    {
        // Sets Gamestate
        GameStateManager.Instance.SetCurrentGameState(GameStates.Playing);
        // Starts the game
        LevelManager.Instance.SetCurrentLevel(PlayerPrefs.GetInt("CurrentLevel", 0)-1);
        LevelManager.Instance.LoadNextLevel();
        PlayerManager.Instance.SpawnPlayer(LevelManager.Instance.GetCurrentLevel());
    }
    private bool CheckForSave()
    {
        return 0 == PlayerPrefs.GetInt("CurrentLevel", 0);
    }
    public void NextLevel()
    {
        LevelManager.Instance.LoadNextLevel();
        PlayerManager.Instance.SpawnPlayer(LevelManager.Instance.GetCurrentLevel());
    }
}