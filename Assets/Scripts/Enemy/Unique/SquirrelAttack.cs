using UnityEngine;

public class SquirrelAttack : EnemyAttack
{
    private GameObject acornPrefab;
    private float projectileSpeed;
    private float attackDamage;
    private float projectileLifeTime;
    public void Init(GameObject acornPrefab, float projectileSpeed, float attackDamage, float projectileLifeTime)
    {
        this.acornPrefab = acornPrefab;
        this.projectileSpeed = projectileSpeed;
        this.attackDamage = attackDamage;
        this.projectileLifeTime = projectileLifeTime;
    }

    public override void Attack()
    {
        base.Attack();
        GameObject acorn = Instantiate(acornPrefab, transform.position, Quaternion.identity);
        Vector2 direction = GetComponent<SquirrelEnemy>().GetVectorToPlayer().normalized;
        acorn.AddComponent<Acorn>().SetDamage(attackDamage);
        acorn.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        Destroy(acorn, projectileLifeTime);
    }
}