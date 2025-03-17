using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [BeginGroup("Attack Settings")]
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public float attackCooldown = 0;
    [EndGroup, SerializeField]
    private float lastAttackTime;

    /// <summary>
    /// Checks whether you can atack player
    /// </summary>
    /// <param name="distanceToPlayer">Distance from the enemy to the player</param>
    /// <returns>True or False if player is in range</returns>
    public bool CanAttack(float distanceToPlayer)
    {
        return distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown;
    }

    /// <summary>
    /// Starts an Enemy Attack
    /// </summary>
    public void Attack()
    {
        Debug.Log("Enemy attacks!!!");
        lastAttackTime = Time.time;
    }
}