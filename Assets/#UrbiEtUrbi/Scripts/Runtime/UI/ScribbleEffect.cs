using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PrimeTween;
using UnityEngine.Events;

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



    private void Awake()
    {
        image.material = new Material(ScribbleMaterial);
    }

    public void Play()
    {
        gameObject.SetActive(true);
        Tween.Custom(0, 0.999f, Duration, (x) =>
           {
               image.material.SetFloat("_Cutoff", x);

           }, ease: Ease).OnComplete(() => OnComplete.Invoke());
    }
}
