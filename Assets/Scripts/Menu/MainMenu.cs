using UnityEngine;
using UnityEngine.SceneManagement;
using Ami.BroAudio;

public class MainMenu : LocalManager
{
    [SerializeField, SceneDetails]
    SerializedScene scene;

    [SerializeField]
    SoundID music;


    private void Start()
    {
        music.Play();
    }

    public void PlayGame()
   {
        BroAudio.Stop(music);
        MainManager.Instance.LoadNewScene(scene.BuildIndex);
   } 

   public void QuitGame()
   {
      Application.Quit();
   }
}
