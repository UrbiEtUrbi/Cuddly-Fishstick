using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [BeginGroup("Movement Settings")]
    public float moveSpeed = 2.0f;
    public float stoppingDistance = 1.0f;
    [EndGroup, SerializeField]
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowardsPlayer(Vector2 direction)
    {
        rb.linearVelocity = direction * moveSpeed;   
    }

    public void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;
    }
}