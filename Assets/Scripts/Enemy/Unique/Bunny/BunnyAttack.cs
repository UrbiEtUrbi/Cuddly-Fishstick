using UnityEngine;

public class BunnyAttack : EnemyAttack
{
    private float chargeSpeed;
    private float chargeUpTime;
    private BunnyEnemy bunnyEnemy;
    private Animator animator;
    public void Init(float chargeSpeed, float chargeUpTime, BunnyEnemy bunnyEnemy, Animator animator)
    {
        this.chargeSpeed = chargeSpeed;
        this.chargeUpTime = chargeUpTime;
        this.bunnyEnemy = bunnyEnemy;
        this.animator = animator;
    }

    public override void Attack()
    {
        base.Attack();
        animator.SetBool("Charging", true);
        Invoke(nameof(Charge), chargeUpTime);
    }

    /// <summary>
    /// Returns a bool of whether the attack is currently charging up
    /// </summary>
    /// <returns>True if the enemy can attack False if the enemy is still charging</returns>
    public void Charge()
    {
        animator.SetBool("Charging", false);
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = bunnyEnemy.GetVectorToPlayer().normalized * chargeSpeed;
    }
}