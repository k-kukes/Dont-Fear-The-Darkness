using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public TextMeshProUGUI batteryText;
    public RawImage batteryImage;
    public RawImage keyImage;
    private InventorySystem inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
        
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);

        UpdateInventoryUI(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryPanel != null)
            {
                inventoryPanel.SetActive(!inventoryPanel.activeSelf);
                
                if (inventoryPanel.activeSelf)
                {
                    UpdateInventoryUI();
                }
            }
        }

        if (inventoryPanel != null && inventoryPanel.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C pressed while inventory open → calling Combine");
            if (inventory != null)
            {
                inventory.CombineBatteryWithFlashlight();
            }

            UpdateInventoryUI(); 
        }
    }

    private void UpdateInventoryUI()
    {
        if (inventory == null) return;

        if (batteryText != null)
        {
            batteryText.text = "Batteries: " + inventory.batteryCount;
        }

        if (batteryImage != null)
        {
            batteryImage.enabled = (inventory.batteryCount > 0);
        }

        if (ChestManager.instance.hasChestKey) {
            keyImage.enabled = true;
        } else {
            keyImage.enabled = false;
        }
    }
}