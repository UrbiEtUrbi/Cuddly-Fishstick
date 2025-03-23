using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 2.0f;

    private float runAwaySpeed = 2.0f;
    private float stoppingDistance = 1.0f;
    private Rigidbody2D rb;

    public void Init(float moveSpeed, float stoppingDistance, float runAwaySpeed)
    {
        rb = GetComponent<Rigidbody2D>();
        this.moveSpeed = moveSpeed;
        this.stoppingDistance = stoppingDistance;
        this.runAwaySpeed = runAwaySpeed;
    }

    public void MoveTowardsPlayer(Vector2 direction,float distance, bool runAway = false)
    {
        if (!runAway && (rb.position + direction * Time.fixedTime * moveSpeed).magnitude > distance)
        {

            rb.linearVelocity = direction *  moveSpeed;
        }
        else if(runAway)
        {
            rb.linearVelocity = direction *runAwaySpeed;
        }
    }

    public void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;
    }
}