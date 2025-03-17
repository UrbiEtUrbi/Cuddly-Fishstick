using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    [SerializeField]
    SoundID sound;


    [SerializeField]
    bool PlayOnAwake;

    [SerializeField]
    bool KeepAlive;



    void Start()
    {
        if (PlayOnAwake)
        {
            Play();
        }
    }

    void Play() {
        BroAudio.Play(sound);
        if (!KeepAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")){
            Play();
        }
    }

}
