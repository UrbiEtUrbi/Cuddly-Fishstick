using UnityEngine;
using Ami.BroAudio;
public class SquirrelEnemy : Enemy
{
    [Header("Attack Settings(extra)")]
    public GameObject acornPrefab;
    public float projectileSpeed;
    public float projectileLifeTime;
    public Animator attackAnimator;
    [SerializeField]
    SoundID throwNut, fly;

    private SquirrelAttack squirrelAttack;
    public override void Start()
    {   
        squirrelAttack = gameObject.AddComponent<SquirrelAttack>();
        squirrelAttack.Init(acornPrefab, projectileSpeed, attackDamage, projectileLifeTime, attackAnimator,throwNut,fly,attackSound);
        attack = squirrelAttack;
        base.Start();
    }

}