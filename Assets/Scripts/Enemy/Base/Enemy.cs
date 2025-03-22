using Ami.BroAudio;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Header("Animation Settings")]
    public SpriteRenderer spriteRenderer;

    [Header("Attack Settings")]
    [Tooltip("How close the enemy needs to be to attack")]
    public float attackRange = 1.5f;
    [Range(0.1f, 10.0f)]
    [Tooltip("Amount of damage dealt per attack")]
    public float attackDamage = 1.0f;
    [Range(0.1f, 5.0f)]
    [Tooltip("Time between attacks in seconds")]
    public float attackCooldown = 0.5f;

    [Header("Health Settings")]
    [Range(1.0f, 100.0f)]
    public float maxHealth = 10.0f;
    public SoundID soundID;

    [Header("Movement Settings")]
    [Range(0.5f, 10.0f)]
    [Tooltip("Enemy movement speed")]
    public float moveSpeed = 2.0f;
    [Range(0.1f, 5.0f)]
    [Tooltip("Distance at which the enemy stops following the player")]
    public float stoppingDistance = 1.0f;

    [Range(0.1f, 5.0f)]
    [Tooltip("Distance at which the enemy stops following the player")]
    public float runAwayDistance = 1.0f;

    [SerializeField]
    float DetectionDistance;

    [SerializeField]
    float LoseInterestTime;


    [SerializeField]
    bool moveAway;


    float loseInterestTimer;

    float idleTimer;

    protected GameObject player;
    protected EnemyHealth health;
    protected EnemyMovement movement;
    protected EnemyAttack attack;
    protected EnemyAnimation enemyAnimation;
    protected EnemyStateManager stateManager = new EnemyStateManager();
    public UnityEvent OnDeath;

    public virtual void Start()
    {
        player ??= GameObject.FindWithTag("Player");

        health ??= gameObject.AddComponent<EnemyHealth>();
        health?.Init(maxHealth, soundID);

        movement ??= gameObject.AddComponent<EnemyMovement>();
        movement?.Init(moveSpeed, stoppingDistance);

        attack ??= gameObject.AddComponent<EnemyAttack>();
        attack?.Init(attackRange, attackCooldown);

        enemyAnimation ??= gameObject.AddComponent<EnemyAnimation>();
        enemyAnimation?.Init(spriteRenderer);
        
        health.OnDeath += HandleDeath;
        stateManager.SetState(EnemyState.Idleing);
        EnemyManager.Instance.RegisterEnemy(gameObject);
    }

    private void Update()
    {
        if (player != null)
        {
            HandleState();
        }
        loseInterestTimer -= Time.deltaTime;
        idleTimer -= Time.deltaTime;



    }

    /// <summary>
    /// Decides what the enemy should be doing based off the state and distance to player
    /// </summary>
    protected virtual void HandleState()
    {
        Vector2 vectorToPlayer = GetVectorToPlayer();
        Vector2 direction = vectorToPlayer.normalized;
        float distanceToPlayer = vectorToPlayer.magnitude;

        

        switch (stateManager.CurrentState)
        {
            case EnemyState.Moving:
                enemyAnimation.FlipSprite(direction);
                if (distanceToPlayer < runAwayDistance && moveAway)
                {
                    movement.MoveTowardsPlayer(-direction);
                }
                else
                {
                    movement.MoveTowardsPlayer(direction);
                }

                if(attack.CanAttack() && attack.NeedsMoving(distanceToPlayer))
                {
                    stateManager.SetState(EnemyState.Attacking);
                    movement.StopMoving();
                }
                break;

            case EnemyState.Attacking:
                enemyAnimation.FlipSprite(direction);
                if (attack.CanAttack())
                {
                    attack.Attack();
                }
                if (!attack.NeedsMoving(distanceToPlayer))
                {
                    stateManager.SetState(EnemyState.Moving);
                }
                break;

            case EnemyState.Dying:
                Destroy(gameObject);
                OnDeath.Invoke();
                EnemyManager.Instance.UnregisterEnemy(gameObject);
                break;

            case EnemyState.Searching:
                enemyAnimation.FlipSprite(direction);
                if (loseInterestTimer <= 0)
                {

                    stateManager.SetState(EnemyState.Idleing);
                }
                if (distanceToPlayer < DetectionDistance)
                {
                    stateManager.SetState(EnemyState.Moving);
                }
                break;

            case EnemyState.Idleing:
                if (idleTimer < -1)
                {
                    idleTimer = 2;
                }
                if (distanceToPlayer < DetectionDistance)
                {
                    stateManager.SetState(EnemyState.Moving);
                }
                break;

                
        }

        if (distanceToPlayer > DetectionDistance && stateManager.CurrentState != EnemyState.Idleing)
        {
            loseInterestTimer = LoseInterestTime;
            stateManager.SetState(EnemyState.Searching);
        }

        
    }

    /// <summary>
    /// Recieves the death event and sets the enemy state appropriately.
    /// </summary>
    private void HandleDeath()
    {
        stateManager.SetState(EnemyState.Dying);
    }

    /// <summary>
    /// Uses enemy position and player position to find the vector distance to the player
    /// </summary>
    /// <returns>Vector Distance from enemy to player</returns>
    public Vector2 GetVectorToPlayer()
    {
        return player.transform.position - transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionDistance);
    }
}