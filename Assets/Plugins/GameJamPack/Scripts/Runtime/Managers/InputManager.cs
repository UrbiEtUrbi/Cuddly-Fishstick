using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : GenericSingleton<InputManager>
{
    [HideInInspector]
    public UnityEvent<float> Horizontal = new UnityEvent<float>();
    [HideInInspector]
    public UnityEvent<float> Vertical = new UnityEvent<float>();

    [HideInInspector]
    public UnityEvent<bool> Attack = new UnityEvent<bool>();





    void OnHorizontal(InputValue inputValue)
    {
        
        var horizontalInputRaw = inputValue.Get<float>();
        Horizontal.Invoke(horizontalInputRaw);
        

    }

    void OnVertical(InputValue inputValue)
    {
       
        var vertInputRaw = inputValue.Get<float>();
        Vertical.Invoke(vertInputRaw);
        

    }

    void OnAttack(InputValue inputValue)
    {

        var isPressed = inputValue.Get<float>();
        Attack.Invoke(isPressed > 0);
    }


    
   
}
