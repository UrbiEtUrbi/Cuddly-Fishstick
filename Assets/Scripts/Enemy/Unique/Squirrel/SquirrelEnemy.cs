using UnityEngine;

public class SquirrelEnemy : Enemy
{
    [Header("Attack Settings(extra)")]
    public GameObject acornPrefab;
    public float projectileSpeed;
    public float projectileLifeTime;

    private SquirrelAttack squirrelAttack;
    public override void Start()
    {   
        squirrelAttack = gameObject.AddComponent<SquirrelAttack>();
        squirrelAttack.Init(acornPrefab, projectileSpeed, attackDamage, projectileLifeTime);
        attack = squirrelAttack;
        base.Start();
    }

}