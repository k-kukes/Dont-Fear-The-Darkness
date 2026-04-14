using UnityEngine;
using TMPro;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public TextMeshProUGUI batteryText;
    private InventorySystem inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryPanel != null)
                inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Debug.Log("Inventory toggled");
        }

        if (inventoryPanel != null && inventoryPanel.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C pressed while inventory open → calling Combine");
            if (inventory != null)
                inventory.CombineBatteryWithFlashlight();

            if (batteryText != null)
                batteryText.text = "Batteries: " + inventory.batteryCount;
        }
    }
}