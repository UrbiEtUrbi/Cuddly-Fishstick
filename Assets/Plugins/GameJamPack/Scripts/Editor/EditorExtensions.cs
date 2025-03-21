using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Reporting;

[InitializeOnLoad]
public class EditorExtensions
{

    [MenuItem("Tools/Clear Saves", false, 0)]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    #region Play From First Scene
    const string playFirstSceneStr = "Tools/Always Start From Scene 0";
    static bool playFirstScene
    {
        get => EditorPrefs.GetBool("scene0", false);
        set => EditorPrefs.SetBool("scene0", value);
    }

    [MenuItem(playFirstSceneStr, false, 150)]
    private static void PlayFromFirstSceneCheckMenu()
    {
        playFirstScene = !playFirstScene;
        Menu.SetChecked(playFirstSceneStr, playFirstScene);

        ShowNotifyOrLog(playFirstScene ? "Play from scene 0" : "Play from current scene");
    }

    [MenuItem(playFirstSceneStr, true)]
    private static bool PlayFromFirstSceneCheckMenuValidate()
    {
        Menu.SetChecked(playFirstSceneStr, playFirstScene);
        return true;
    }

    static void ShowNotifyOrLog(string msg)
    {
        if (Resources.FindObjectsOfTypeAll<SceneView>().Length > 0)
            EditorWindow.GetWindow<SceneView>().ShowNotification(new GUIContent(msg));
        else
            Debug.Log(msg); // When there's no scene view opened, we just print a log
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadFirstSceneAtGameBegins()
    {
        if (!playFirstScene)
            return;

        if (EditorBuildSettings.scenes.Length == 0)
        {
            ShowNotifyOrLog("The scene build list is empty. Can't play from first scene.");
            return;
        }

        foreach (var go in UnityEngine.Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
            go.SetActive(false);

        SceneManager.LoadScene(0);
    }
    #endregion
}

public class CheckBeforeBuild : UnityEditor.Build.IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        PlayerSettings.SplashScreen.showUnityLogo = false;
      


    }

   
}
