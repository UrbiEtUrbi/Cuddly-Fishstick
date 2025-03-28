using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    //fields
    [BeginGroup("Movement")]
    [SerializeField]
    float MaxSpeed;


    [SerializeField]
    float Acceleration;

    [EndGroup, SerializeField]
    float Drag;


    //private fields
    [SerializeField]
    SpriteRenderer m_Sprite;
    Vector2 m_Velocity;
    Vector2 m_Speed;
    Rigidbody2D m_Rb;

    //properties
    public int Direction => m_Sprite.flipX ? -1 : 1;
    public SpriteRenderer Sprite => m_Sprite;

    //public fields
    [HideInInspector]
    public bool lockOrientation;


    [SerializeField]
    Animator _Animator;

    [SerializeField]
    Transform Art;

    [HideInInspector]
    public Transform ArtObject;


    [HideInInspector]
    public bool Slowing;


    PlayerAttack m_PlayerAttack;




    void OnEnable()
    {

        m_PlayerAttack = GetComponent<PlayerAttack>();
        m_Rb = GetComponent<Rigidbody2D>();

        if (InputManager.Instance != null)
        {
            InputManager.Instance.Horizontal.AddListener(OnHorizontal);
            InputManager.Instance.Vertical.AddListener(OnVertical);
            InputManager.Instance.Attack.AddListener(OnAttack);
        }
    }

    void OnDisable()
    {

        if (InputManager.Instance != null)
        {
            InputManager.Instance.Horizontal.RemoveListener(OnHorizontal);
            InputManager.Instance.Vertical.RemoveListener(OnVertical);
            InputManager.Instance.Attack.RemoveListener(OnAttack);
        }

    }




    void FixedUpdate()
    {

        if (m_Speed == default)
        {
            m_Velocity *= Drag;
        }
        else
        {

            m_Velocity += m_Speed;
        }

        m_PlayerAttack.AttackDirection = m_Speed.normalized;
        var maxSpeed = MaxSpeed;
        m_Velocity = m_Velocity.normalized * Mathf.Min((m_Velocity).magnitude, maxSpeed);

     

        m_Rb.linearVelocity = m_Velocity;


        _Animator.speed = Mathf.Clamp01(m_Rb.linearVelocity.magnitude);
        if (Mathf.Abs(m_Rb.linearVelocity.x) >= Mathf.Abs(m_Rb.linearVelocity.y))
        {

            _Animator.SetFloat("xy", m_Rb.linearVelocity.x <= 0 ? 0 : 0.5f);
        }
        else
        {
            _Animator.SetFloat("xy", m_Rb.linearVelocity.y <= 0 ? 0.8f : 1);
        }
    }

  


    void OnHorizontal(float amount)
    {
        m_Speed = new Vector2(amount * Acceleration, m_Speed.y);
    }


    void OnVertical(float amount)
    {
        m_Speed = new Vector2(m_Speed.x, amount * Acceleration);
    }

 

    void OnAttack(bool isPressed)
    {
      
    }

    void OnEndAttack()
    {
      
    }

    void OnJump(bool jump)
    {
       

    }
}
