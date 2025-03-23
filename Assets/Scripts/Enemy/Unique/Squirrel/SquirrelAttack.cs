using UnityEngine;
using Ami.BroAudio;
public class SquirrelAttack : EnemyAttack
{
    private GameObject acornPrefab;
    private float projectileSpeed;
    private float attackDamage;
    private float projectileLifeTime;
    private Animator animator;

    SoundID throwNut, nutFly, hit;


    public void Init(GameObject acornPrefab, float projectileSpeed, float attackDamage, float projectileLifeTime, Animator animator, SoundID throwNut, SoundID nutFly, SoundID hit)
    {
        this.acornPrefab = acornPrefab;
        this.projectileSpeed = projectileSpeed;
        this.attackDamage = attackDamage;
        this.projectileLifeTime = projectileLifeTime;
        this.animator = animator;
        this.throwNut = throwNut;
        this.nutFly = nutFly;
        this.hit = hit;
    }

    public override void Attack()
    {
        base.Attack();
        animator.SetBool("IsThrowing", true);
        Invoke(nameof(SpawnAcorn), 0.5f);
    }

     private void SpawnAcorn()
     {
        animator.SetBool("IsThrowing", false);
        GameObject acorn = Instantiate(acornPrefab, transform.position, Quaternion.identity);
        Vector2 direction = GetComponent<SquirrelEnemy>().GetVectorToPlayer().normalized;
        acorn.AddComponent<Acorn>().SetDamage(attackDamage,hit);
        acorn.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        Destroy(acorn, projectileLifeTime);
        throwNut.Play();
        nutFly.Play().SetDelay(0.1f);

     }
}