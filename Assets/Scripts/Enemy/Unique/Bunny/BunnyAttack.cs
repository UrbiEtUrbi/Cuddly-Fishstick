using UnityEngine;

using Ami.BroAudio;
public class BunnyAttack : EnemyAttack
{
    private float chargeSpeed;
    private float chargeUpTime;
    private BunnyEnemy bunnyEnemy;
    private Animator animator;
    SoundID attack;
    public void Init(float chargeSpeed, float chargeUpTime, BunnyEnemy bunnyEnemy, Animator animator,SoundID attack)
    {
        this.chargeSpeed = chargeSpeed;
        this.chargeUpTime = chargeUpTime;
        this.bunnyEnemy = bunnyEnemy;
        this.animator = animator;
        this.attack = attack;
    }


    public override bool CanAttack()
    {
        return base.CanAttack();
    }

    public override void Attack()
    {
        base.Attack();


        animator.SetBool("IsStanding", true);
        
        Invoke(nameof(Charge), chargeUpTime);
    }

    /// <summary>
    /// Returns a bool of whether the attack is currently charging up
    /// </summary>
    /// <returns>True if the enemy can attack False if the enemy is still charging</returns>
    public void Charge()
    {
        animator.SetBool("IsStanding", false);
        animator.SetBool("IsCharging", true);
        attack.Play();
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = bunnyEnemy.GetVectorToPlayer().normalized * chargeSpeed;
    }
}