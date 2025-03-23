using UnityEngine;

using Ami.BroAudio;
public class Acorn : MonoBehaviour
{
    private float damage;
    SoundID Hit;

    public void SetDamage(float damage, SoundID hit)
    {
        this.damage = damage;
        Hit = hit;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Hit.Play();
            }

            Destroy(gameObject);
        }
    }
}