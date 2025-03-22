using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ami.BroAudio;
public class Plant : MonoBehaviour
{

    [SerializeField]
    SoundID HitSound;

    [SerializeField]
    float health;


    

    private void Start()
    {
        EnemyManager.Instance.RegisterEnemy(gameObject);
        var eh = gameObject.AddComponent<EnemyHealth>();
        eh.Init(health, HitSound);
        eh.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        Destroy(gameObject);
      
        EnemyManager.Instance.UnregisterEnemy(gameObject);

    }
}
