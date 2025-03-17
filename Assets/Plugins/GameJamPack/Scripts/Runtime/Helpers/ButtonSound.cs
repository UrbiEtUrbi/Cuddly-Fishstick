using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ami.BroAudio;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    SoundID sound;


    private void Start()
    {

        var button = GetComponent<Button>();
        if (button) {
            button.onClick.AddListener(() => BroAudio.Play(sound));
        }
    }
}
