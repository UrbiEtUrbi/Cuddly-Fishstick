using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Flips sprite to face the player.
    /// </summary>
    /// <param name="direction"></param>
    public void FlipSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (direction.y > 0)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }
    }
}