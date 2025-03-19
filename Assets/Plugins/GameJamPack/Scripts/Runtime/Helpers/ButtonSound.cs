using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ami.BroAudio;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    SoundID sound;

    public bool IsSet => sound.IsValid();



    public void SetSound(SoundID sound)
    {
        this.sound = sound;
    }
    private void Start()
    {

        var button = GetComponent<Button>();
        if (button) {
            button.onClick.AddListener(() => BroAudio.Play(sound));
        }
    }
}
