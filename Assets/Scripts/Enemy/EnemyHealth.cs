using UnityEngine;
using Ami.BroAudio;
public class EnemyHealth : MonoBehaviour, IDamageable
{
    [BeginGroup("Health Settings")]
    [SerializeField]public float maxHealth = 10.0f;   
    [EndGroup, SerializeField]
    private float currentHealth;

    [SerializeField]
    SoundID soundID;
 

    public event System.Action OnDeath; // Event for death

    private void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Enemy will take damage based on amount given in parameter.
    /// </summary>
    /// <param name="amount">Float amount of damage</param>
    public void TakeDamage(float amount)
    {
        soundID.Play();
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died!");
        OnDeath?.Invoke(); // Trigger death event
    }
}