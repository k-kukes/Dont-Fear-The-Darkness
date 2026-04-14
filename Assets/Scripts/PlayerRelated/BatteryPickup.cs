using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public int batteryAmount = 1;

    public void Interact()
    {
        InventorySystem inv = FindFirstObjectByType<InventorySystem>();
        if (inv != null)
        {
            inv.AddBattery(batteryAmount);
            gameObject.SetActive(false);
            Debug.Log("Battery disappeared after pickup");
        }
    }
}