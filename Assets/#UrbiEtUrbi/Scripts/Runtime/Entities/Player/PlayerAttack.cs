using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using Ami.BroAudio;

public class PlayerAttack : MonoBehaviour
{

    float m_Damage;
    float m_Duration;
    float m_Delay;
    Vector2 m_Size;


    [SerializeField]
    ParticleSystem AttackParticles;

    [SerializeField]
    SoundID AttackSound;

    [HideInInspector]
    public Vector2 AttackDirection = new Vector2(1, 0);


    bool m_IsAttacking;
    bool m_CanAttack;

    HashSet<IDamageable> DealtDamage;

    [SerializeField]
    LayerMask TargetLayer;

    private void Start()
    {

        //TODO move this into a player script
        Init(1, 0.4f, 0.1f, new Vector2(0.5f, 0.5f));
    }

    public void Init(float damage, float duration, float delay, Vector2 size)
    {
        DealtDamage = new();
        m_Damage = damage;
        m_Duration = duration;
        m_Delay = delay;
        m_Size = size;
        m_CanAttack = true;
    }

   

    void OnEnable()
    {
        InputManager.Instance?.Attack.AddListener(OnAttack);
    }

    void OnDisable()
    {

        InputManager.Instance?.Attack.RemoveListener(OnAttack);
    }

    void OnAttack(bool isAttacking)
    {
        if (!isAttacking || m_IsAttacking || !m_CanAttack)
        {
            return;
        }
        AttackSound.Play();
        DealtDamage.Clear();

        m_IsAttacking = true;
        m_CanAttack = false;

        AttackParticles.transform.LookAt(transform.position +(Vector3)AttackDirection);
        AttackParticles.Play();

        Tween.Delay(m_Duration, () => m_IsAttacking = false);
        Tween.Delay(m_Duration+m_Delay, () => m_CanAttack = true);
    }

    private void FixedUpdate()
    {
        if (m_IsAttacking)
        {
            var colliders = Physics2D.OverlapBoxAll(transform.position + (Vector3)AttackDirection *0.5f, m_Size,0, TargetLayer);
            foreach (var collider in colliders)
            {
                if (collider != null)
                {
                    if (collider.TryGetComponent<IDamageable>(out var damageable))
                    {
                        if (DealtDamage.Contains(damageable))
                        {
                            continue;
                        }
                        damageable.TakeDamage(m_Damage);
                        DealtDamage.Add(damageable);
                    }

                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position +(Vector3)AttackDirection*0.5f, m_Size);
    }




}
