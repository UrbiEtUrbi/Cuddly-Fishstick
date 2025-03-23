using Ami.BroAudio;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float maxHealth = 3.0f;   
    private float currentHealth;
    private SoundID soundID, deathSound;
 

    public event System.Action OnDeath; // Event for death
    public UnityEvent<float> PlayerDamageTaken = new UnityEvent<float>();
    public void Init(float maxHealth, SoundID soundID, SoundID deathSound)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.soundID = soundID;
        this.deathSound = deathSound;
    }

    /// <summary>
    /// Player will take damage based on amount given in parameter.
    /// </summary>
    /// <param name="amount">Float amount of damage</param>
    public void TakeDamage(float amount)
    {
      
        currentHealth -= amount;
        PlayerDamageTaken.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            soundID.Play();
        }
    }

    private void Die()
    {
        deathSound.Play();
        OnDeath?.Invoke(); // Trigger death event
    }
}