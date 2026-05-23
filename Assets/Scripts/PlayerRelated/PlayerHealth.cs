using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public Slider healthSlider;
    public CanvasGroup bloodOverlayGroup;
    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (bloodOverlayGroup != null)
            bloodOverlayGroup.alpha = 1f - (currentHealth / maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}