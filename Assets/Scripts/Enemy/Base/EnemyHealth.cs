using UnityEngine;
using Ami.BroAudio;
public class EnemyHealth : MonoBehaviour, IDamageable
{

    private float maxHealth;   
    private float currentHealth;

    private SoundID soundID, deathSound;
 

    public event System.Action OnDeath; // Event for death

    public void Init(float maxHealth, SoundID soundID, SoundID deathSound)
    {
        this.maxHealth = maxHealth;
        this.soundID = soundID;
        currentHealth = maxHealth;
        this.deathSound = deathSound;
    }

    /// <summary>
    /// Enemy will take damage based on amount given in parameter.
    /// </summary>
    /// <param name="amount">Float amount of damage</param>
    public void TakeDamage(float amount)
    {
        
        currentHealth -= amount;
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
        Debug.Log(gameObject.name + " died!");
        OnDeath?.Invoke(); // Trigger death event
    }
}