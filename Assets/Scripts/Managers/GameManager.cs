using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Sets Gamestate
        GameStateManager.Instance.SetCurrentGameState(GameStates.Playing);
        // Starts the game
        LevelManager.Instance.SetCurrentLevel(-1);
        LevelManager.Instance.LoadNextLevel();
    }
}
