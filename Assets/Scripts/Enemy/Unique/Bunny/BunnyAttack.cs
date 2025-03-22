using UnityEngine;

public class BunnyAttack : EnemyAttack
{
    private float chargeSpeed;
    private float chargeUpTime;
    private float attackDamage;
    private float startChargeTime;

    public void Init(float chargeSpeed, float chargeUpTime, float attackDamage)
    {
        this.chargeSpeed = chargeSpeed;
        this.chargeUpTime = chargeUpTime;
        this.attackDamage = attackDamage;
    }

    public override void Attack()
    {
        base.Attack();
    }

    public void StartCharging()
    {
        startChargeTime = Time.time;
    }

    /// <summary>
    /// Returns a bool of whether the attack is currently charging up
    /// </summary>
    /// <returns>True if the enemy can attack False if the enemy is still charging</returns>
    public bool IsCharging()
    {
        return startChargeTime + chargeUpTime <= Time.time;
    }
}