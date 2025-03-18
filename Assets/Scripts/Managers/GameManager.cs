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
        // Sets Gamestate
        GameStateManager.Instance.SetCurrentGameState(GameStates.Playing);
        // Starts the game
        LevelManager.Instance.SetCurrentLevel(-1);
        LevelManager.Instance.LoadNextLevel();
    }
}
