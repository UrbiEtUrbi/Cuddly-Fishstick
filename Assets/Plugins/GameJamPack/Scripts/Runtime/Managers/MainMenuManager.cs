using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class MainMenuManager : LocalManager
{


    [SerializeField, SceneDetails]
    SerializedScene Scene;

    public override void Init()
    {
        base.Init();
     
    }

    public void OnPlay()
    {
        MainManager.Instance.LoadNewScene(Scene.BuildIndex);
    }
}
