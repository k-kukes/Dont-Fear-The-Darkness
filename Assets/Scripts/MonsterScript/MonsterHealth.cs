using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public float maxHealth = 150f;
    public float currentHealth = 150f;
    public Slider healthSlider;
    public GameObject victoryPanel;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (victoryPanel != null)
            victoryPanel.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}