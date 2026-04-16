using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public static int Sanity = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void reduceSanity(int amount)
    {
        Sanity -= amount;
    }
}
