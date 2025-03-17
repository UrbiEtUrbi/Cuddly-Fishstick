using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
      LevelManager.Instance.LoadNextLevel();
   } 

   public void QuitGame()
   {
      Application.Quit();
   }
}
