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
    /// 
    public void FlipSprite(Vector2 direction)
    {


        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {

            animator.SetFloat("xy", 0);
            animator.transform.localScale = new Vector3(-Mathf.Sign(direction.x), 1, 1);
        }
        else
        {
            animator.SetFloat("xy", direction.y <= 0 ? 0.5f : 1);
        }
      
    }
}