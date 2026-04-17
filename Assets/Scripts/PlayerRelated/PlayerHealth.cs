using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public Image bloodOverlay;
    public float maxRedAlpha = 0.7f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            TakeDamage(10);
        }

        ApplyVisuals();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
    }

    void ApplyVisuals()
    {
        float hurtFactor = 1f - (currentHealth / maxHealth);

        if (hurtFactor > 0.35f)
        {
            float alpha = (hurtFactor - 0.35f) / 0.65f * maxRedAlpha;
            bloodOverlay.color = new Color(1,0,0, alpha);
        } else {
            bloodOverlay.color = new Color(1,0,0,0.8f);
        }
    }
}