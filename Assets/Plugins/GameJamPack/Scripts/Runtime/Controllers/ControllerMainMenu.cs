using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerMainMenu : ControllerLocal
{


    [SerializeField, SceneDetails]
    SerializedScene Scene;



    public override void Init()
    {
        base.Init();
     
    }

    public void OnPlay()
    {
        ControllerGameFlow.Instance.LoadNewScene(Scene.BuildIndex);
    }




  






}
