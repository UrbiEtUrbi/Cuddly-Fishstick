using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocalManager : MonoBehaviour
{

    protected bool isInitialized = false;
    public virtual void Init()
    {

        isInitialized = true;
    }
}
