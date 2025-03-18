using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : LocalManager
{
    [SerializeField, SceneDetails]
    SerializedScene scene;
    public void PlayGame()
   {
        MainManager.Instance.LoadNewScene(scene.BuildIndex);
   } 

   public void QuitGame()
   {
      Application.Quit();
   }
}
