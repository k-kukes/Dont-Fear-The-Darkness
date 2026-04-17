using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float maxRedAlpha = 0.7f;
    
    public CanvasGroup bloodOverlayGroup; 

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
        
        float targetAlpha = Mathf.InverseLerp(0.35f, 1f, hurtFactor) * maxRedAlpha;
        bloodOverlayGroup.alpha = targetAlpha;
    }
}