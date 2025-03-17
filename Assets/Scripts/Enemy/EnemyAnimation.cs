using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    /// <summary>
    /// Flips sprite to face the player.
    /// </summary>
    /// <param name="direction"></param>
    public void FlipSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (direction.y > 0)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}