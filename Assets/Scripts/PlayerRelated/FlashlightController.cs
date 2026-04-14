using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlightLight;
    private InventorySystem inventory;
    private bool isOn = false;

    void Awake()
    {
        inventory = FindFirstObjectByType<InventorySystem>();

        if (flashlightLight != null)
        {
            flashlightLight.enabled = false;
            isOn = false;
            Debug.Log("Flashlight forced OFF at start");
        }
        else
        {
            Debug.LogError(" WhiteLight is NOT assigned in the Flashlight Controller!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed");
            if (inventory != null && inventory.flashlightActivated)
            {
                isOn = !isOn;
                flashlightLight.enabled = isOn;
                Debug.Log("Flashlight toggled → " + (isOn ? "ON" : "OFF"));
            }
            else
            {
                Debug.Log("Flashlight still dead - you must combine battery first");
            }
        }
    }

    public bool IsFlashlightOn()
    {
        return isOn;
    }
}