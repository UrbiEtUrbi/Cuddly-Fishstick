using UnityEngine;

public class SquirrelAttack : EnemyAttack
{
    private GameObject acornPrefab;
    private float projectileSpeed;
    private float attackDamage;
    private float projectileLifeTime;
    private Animator animator;
    public void Init(GameObject acornPrefab, float projectileSpeed, float attackDamage, float projectileLifeTime, Animator animator)
    {
        this.acornPrefab = acornPrefab;
        this.projectileSpeed = projectileSpeed;
        this.attackDamage = attackDamage;
        this.projectileLifeTime = projectileLifeTime;
        this.animator = animator;
    }

    public override void Attack()
    {
        base.Attack();
        animator.SetBool("IsThrowing", true);
        Invoke(nameof(SpawnAcorn), 0.5f);
    }

     private void SpawnAcorn()
     {
        GameObject acorn = Instantiate(acornPrefab, transform.position, Quaternion.identity);
        Vector2 direction = GetComponent<SquirrelEnemy>().GetVectorToPlayer().normalized;
        acorn.AddComponent<Acorn>().SetDamage(attackDamage);
        acorn.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        Destroy(acorn, projectileLifeTime);
        animator.SetBool("IsThrowing", false);
     }
}