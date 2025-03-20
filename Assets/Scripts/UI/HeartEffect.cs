using UnityEngine;
using UnityEngine.UI;

public class HeartEffect : MonoBehaviour
{
    public Slider healthSlider;
    public Image fillImage;

    public void SetHeatlh(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth/maxHealth;
    }
}
