using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using PrimeTween;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class LevelMusic : MonoBehaviour
{
    [SerializeField]
    SoundID StartMusic, Loop;


    [SerializeField]
    float playNextAt;

    bool startedPlayingLoop = false;

    private void Start()
    {
        StartPlaying();
    }
    private void Reset()
    {
        BroAudio.Stop(BroAudioType.Music, 0);
        StartPlaying();
    }

    void StartPlaying()
    {
        

        StartMusic.Play().OnUpdate(Check);
       
      
    }

    void Check(IAudioPlayer player)
    {
        if (!startedPlayingLoop)
        {
            if (player.AudioSource.time >= playNextAt)
            {
                startedPlayingLoop = true;
                Loop.Play().AudioSource.time = 110;
            }

        }
    }



  

   
}

