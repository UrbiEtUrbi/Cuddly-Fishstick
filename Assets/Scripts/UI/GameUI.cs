using UnityEngine;

public class GameUI : MonoBehaviour
{
    private HeartEffect slider;
    private float maxHealth;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHealth>().PlayerDamageTaken.AddListener(UpdateHealthDisplay);
        maxHealth = player.GetComponent<Player>().maxHealth;
        slider = gameObject.GetComponent<HeartEffect>();
    }

    private void UpdateHealthDisplay(float amount)
    {
        slider.SetHeatlh(amount, maxHealth);
    }
}