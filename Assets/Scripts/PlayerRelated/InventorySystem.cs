using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int batteryCount = 0;
    public bool hasFlashlight = true;
    public bool flashlightActivated = false;

    public void AddBattery(int amount)
    {
        batteryCount += amount;
        Debug.Log(" Battery picked up! Total batteries now: " + batteryCount);
    }

    public void CombineBatteryWithFlashlight()
    {
        Debug.Log("Combine called - checking...");
        if (hasFlashlight && batteryCount >= 1 && !flashlightActivated)
        {
            batteryCount--;
            flashlightActivated = true;
            Debug.Log(" FLASHLIGHT ACTIVATED! Press F to turn it on");
        }
        else
        {
            Debug.Log("Combine failed. Batteries = " + batteryCount + " | Already activated = " + flashlightActivated);
        }
    }
}