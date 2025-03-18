using UnityEngine;

public enum GameStates {Playing, Paused, GameOver, Win}
public class GameStateManager : MonoBehaviour
{
   public static GameStateManager Instance {get; private set;} 

   private GameStates currentGameState;

   public void Awake()
   {
        if (Instance == null)
        {
            Instance = this;
        }
   }

   public void SetCurrentGameState(GameStates gameState)
   {
        currentGameState = gameState;
   }
}
