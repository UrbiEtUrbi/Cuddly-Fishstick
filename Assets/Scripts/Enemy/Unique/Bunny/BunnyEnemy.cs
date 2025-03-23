using UnityEngine;

public class BunnyEnemy : Enemy
{
    [Header("Attack Settings(extra)")]
    public float chargeSpeed;
    public float chargeUpTime;

    private BunnyAttack bunnyAttack;
    public override void Start()
    {
        bunnyAttack = gameObject.AddComponent<BunnyAttack>();
        bunnyAttack.Init(chargeSpeed, chargeUpTime, this, animator,attackSound);
        attack = bunnyAttack;
        base.Start();
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

    

    protected override void Update()
    {
        base.Update();



        if (stateManager.CurrentState != EnemyState.Attacking)
        {
            animator.SetBool("IsCharging", false);
        }

        if (stateManager.CurrentState == EnemyState.Attacking)
        {
            animator.SetBool("IsWalking", false);
        }
        if (stateManager.CurrentState == EnemyState.Moving)
        {
            animator.SetBool("IsCharging", false);
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsStanding", false);
        }
        if (stateManager.CurrentState == EnemyState.Idleing)
        {
            animator.SetBool("IsCharging", false);
            animator.SetBool("IsStanding", true);
            animator.SetBool("IsWalking", false);
        }
    }
}