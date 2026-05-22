using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public void PickUp()
    {
        ChestManager.instance.hasChestKey = true;
        Debug.Log("Key Acquired via Raycast!");

        Destroy(gameObject);
    }
}