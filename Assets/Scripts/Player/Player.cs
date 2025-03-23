using Ami.BroAudio;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 3.0f;
    public SoundID hitSound, DeathSound;
    private PlayerHealth health;

    private void Start()
    {
        health = gameObject.AddComponent<PlayerHealth>();
        health.Init(maxHealth, hitSound, DeathSound);

    }
}