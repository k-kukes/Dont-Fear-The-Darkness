using System.Collections;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlightLight;
    private InventorySystem inventory;
    private static bool isOn = false;
    private float timer = 0;

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

        if (ResourceManager.FlashlightPower <= 0)
        {
            isOn = false;
            flashlightLight.enabled = isOn;
        }

        if (timer > 0.7f)
        {
            timer = 0;
            if (isOn)
            {
                drainBattery();
            }
            else
            {
                ResourceManager.reduceSanity(1);
            }
        }
        else if (isOn)
        {

        }
        timer += Time.deltaTime;



    }

    void drainBattery()
    {
        ResourceManager.DrainPower();

    }
    public static bool IsFlashlightOn()
    {
        return isOn;
    }


}