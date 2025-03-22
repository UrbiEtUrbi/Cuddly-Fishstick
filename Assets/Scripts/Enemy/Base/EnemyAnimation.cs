using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    public void Init(Animator animator)
    {
        this.animator = animator;
    }

    /// <summary>
    /// Flips sprite to face the player.
    /// </summary>
    /// <param name="direction"></param>
    public void FlipSprite(Vector2 direction)
    {
        if (direction.x < 0)
        {
            animator.SetInteger("DirectionX", -1);
        }
        else
        {
            animator.SetInteger("DirectionX", 1);
        }

        if (direction.y > 0)
        {
         //   spriteRenderer.flipY = true;
        }
        else
        {
       //     spriteRenderer.flipY = false;
        }
    }
}