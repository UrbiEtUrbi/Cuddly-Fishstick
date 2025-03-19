using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;

public class ButtonSoundInitializer : MonoBehaviour
{

    [SerializeField]
    SoundID DefaultButtonSound;
  
    void Start()
    {
        var buttons = GetComponentsInChildren<ButtonSound>();
        foreach (var button in buttons)
        {
            if (!button.IsSet)
            {
                button.SetSound(DefaultButtonSound);
            }
        }
    }

  
}
