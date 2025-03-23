using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRandomizer : MonoBehaviour
{

    [SerializeField]
    Sprite[] Sprites;

    private void Awake()
    {

        if (Sprites == null || Sprites.Length == 0)
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, Sprites.Length)];

    }

}
