using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 2.0f;
    private float stoppingDistance = 1.0f;
    private Rigidbody2D rb;

    public void Init(float moveSpeed, float stoppingDistance)
    {
        rb = GetComponent<Rigidbody2D>();
        this.moveSpeed = moveSpeed;
        this.stoppingDistance = stoppingDistance;
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