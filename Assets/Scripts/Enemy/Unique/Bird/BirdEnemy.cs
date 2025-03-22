using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using Ami.BroAudio;
using UnityEngine.Events;

public class BirdEnemy : MonoBehaviour
{


    Rigidbody2D Rigidbody2D;

    [SerializeField]
    float attackDamage;

    [SerializeField]
    float speed;


    [SerializeField]
    Vector4 Bounds;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float Healh;

    [SerializeField]
    SoundID HitSound;

    public UnityEvent OnDeath;
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        var eh = gameObject.AddComponent<EnemyHealth>();
        eh.Init(Healh, HitSound);

        eh.OnDeath += HandleDeath;

    }

    private void Start()
    {
        EnemyManager.Instance.RegisterEnemy(gameObject);
        Reset();
    }
    public void Reset()
    {
        gameObject.SetActive(true);
        bool horizontal = Random.value > 0.5f;
        bool increasing = Random.value > 0.5f;

        float startX;
        float startY;
        float velX = 0;
        float velY = 0;

        if (horizontal)
        {
            startX = increasing ? Bounds.x : Bounds.y;
            velX = increasing ? 1 : -1;
            startY = Random.Range(Bounds.z, Bounds.w) * 0.7f;

        }
        else
        {
            startY = increasing ? Bounds.z : Bounds.w;
            velY = increasing ? 1 : -1;
            startX = Random.Range(Bounds.x, Bounds.y) * 0.7f;
        }

        transform.position = new Vector3(startX, startY, 0);
        Rigidbody2D.MovePosition(new Vector2(startX, startY));
        Rigidbody2D.linearVelocity = speed * new Vector2(velX, velY);
        if (velX != 0)
        {
            animator.transform.localScale = new Vector3(velX, 1, 1);
        }
        else
        {
            animator.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void HandleDeath()
    {
        Destroy(gameObject);
        OnDeath.Invoke();
        EnemyManager.Instance.UnregisterEnemy(gameObject);

    }
    Tween t;
    private void FixedUpdate()
    {
        if(transform.position.x < Bounds.x ||
            transform.position.x > Bounds.y ||
            transform.position.y < Bounds.z ||
            transform.position.y > Bounds.w){
            gameObject.SetActive(false);
            t = Tween.Delay(Random.value * 5, Reset);
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDestroy()
    {
        t.Stop();
    }
}
