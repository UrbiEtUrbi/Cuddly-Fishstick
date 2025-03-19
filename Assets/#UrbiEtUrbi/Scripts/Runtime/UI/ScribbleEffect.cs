using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PrimeTween;
using UnityEngine.Events;
using Ami.BroAudio;

public class ScribbleEffect : MonoBehaviour
{


    [SerializeField]
    Material ScribbleMaterial;

    [SerializeField]
    Image image;

    [SerializeField]
    float Duration;

    [SerializeField]
    Ease Ease;

    [SerializeField]
    UnityEvent OnComplete;

    [SerializeField]
    SoundID ScribbleStart;

    private void Awake()
    {
        image.material = new Material(ScribbleMaterial);
    }

    public void Play()
    {
        gameObject.SetActive(true);
        ScribbleStart.Play();
        Tween.Custom(0, 0.999f, Duration, (x) =>
           {
               image.material.SetFloat("_Cutoff", x);

           }, ease: Ease).OnComplete(() => OnComplete.Invoke());
    }
}
