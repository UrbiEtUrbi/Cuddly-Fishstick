using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
public class Plant : MonoBehaviour
{

    [SerializeField]
    SoundID HitSound, DeathSound;

    [SerializeField]
    float health;


    

    private void Start()
    {
        EnemyManager.Instance.RegisterEnemy(gameObject);
        var eh = gameObject.AddComponent<EnemyHealth>();
        eh.Init(health, HitSound, DeathSound);
        eh.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        Destroy(gameObject);
      
        EnemyManager.Instance.UnregisterEnemy(gameObject);

    }
}
