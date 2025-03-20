using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackRange;
    private float attackCooldown;
    private float lastAttackTime;

    public void Init(float range, float cooldown)
    {
        attackRange = range;
        attackCooldown = cooldown;
    }

    /// <summary>
    /// Checks whether you can atack player based off last attack time
    /// </summary>
    /// <returns>True if enemy can attack False if Enemy can't attack</returns>
    public bool CanAttack()
    {
        return  Time.time > lastAttackTime + attackCooldown;
    }

    /// <summary>
    /// Checks whether you can atack player based off distance
    /// </summary>
    /// <param name="distanceToPlayer"></param>
    /// <returns>True if Player is too far False if player is close enough</returns>
    public bool NeedsMoving(float distanceToPlayer)
    {
        return attackRange >= distanceToPlayer;
    }

    /// <summary>
    /// Starts an Enemy Attack
    /// </summary>
    public virtual void Attack()
    {
        lastAttackTime = Time.time;
    }
}