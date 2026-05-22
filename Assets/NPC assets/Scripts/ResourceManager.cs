using Unity.VectorGraphics;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static GameObject player;
    public static GameObject Monster;
    public static Camera playerCam;
    public static int Sanity = 100;
    public static int Health = 100;
    public static int FlashlightPower = 0;
    public static bool isFood = false;

    public static GameObject currentObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void AddBattery()
    {
        FlashlightPower += 50;
    }

    public static void DrainPower()
    {
        FlashlightPower -= 1;
    }

    public static void activateMonster()
    {
        Monster.SetActive(true);
    }

    public static void reduceSanity(int amount)
    {
        if (Sanity > 0)
        {
            Sanity -= amount;
        }
    }

    public static void increaseSanity(int amount)
    {
        if (Sanity < 100)
        {
            Sanity += amount;
        }
    }

    public static void TakeDamage(int amount)
    {
        Health -= amount;
    }

    public static void Heal(int amount)
    {
        Health += amount;
    }
}
