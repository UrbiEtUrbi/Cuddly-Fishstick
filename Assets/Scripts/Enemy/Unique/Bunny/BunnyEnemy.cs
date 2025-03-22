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
        bunnyAttack.Init(chargeSpeed, chargeUpTime, attackDamage);
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
}