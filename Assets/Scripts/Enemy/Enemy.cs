using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    private EnemyHealth health;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private EnemyAnimation enemyAnimation;
    private EnemyStateManager stateManager;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        stateManager = GetComponent<EnemyStateManager>();

        health.OnDeath += HandleDeath;
        stateManager.SetState(EnemyState.Moving);
    }

    private void Update()
    {
        if (player != null)
        {
            HandleState();
        }
    }

    /// <summary>
    /// Decides what the enemy should be doing based off the state and distance to player
    /// </summary>
    private void HandleState()
    {
        Vector2 vectorToPlayer = GetVectorToPlayer();
        Vector2 direction = vectorToPlayer.normalized;
        float distanceToPlayer = vectorToPlayer.magnitude;

        enemyAnimation.FlipSprite(direction);
        switch (stateManager.CurrentState)
        {
            case EnemyState.Moving:
                movement.MoveTowardsPlayer(direction);
                if (attack.CanAttack(distanceToPlayer))
                {
                    stateManager.SetState(EnemyState.Attacking);
                    movement.StopMoving();
                }
                break;

            case EnemyState.Attacking:
                attack.Attack();
                if (!attack.CanAttack(distanceToPlayer))
                {
                    stateManager.SetState(EnemyState.Moving);
                }
                break;

            case EnemyState.Dying:
                Destroy(gameObject);
                break;
        }
    }

    /// <summary>
    /// Recieves the death event and sets the enemy state appropriately.
    /// </summary>
    private void HandleDeath()
    {
        Debug.Log("Enemy died!");
        stateManager.SetState(EnemyState.Dying);
    }

    /// <summary>
    /// Uses enemy position and player position to find the vector distance to the player
    /// </summary>
    /// <returns>Vector Distance from enemy to player</returns>
    protected Vector2 GetVectorToPlayer()
    {
        return player.transform.position - transform.position;
    }
}