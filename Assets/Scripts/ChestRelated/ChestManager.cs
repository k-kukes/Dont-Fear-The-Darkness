using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public static ChestManager instance;

    public bool hasChestKey = false;

    public bool ChestOpened = false;
    void Awake()
    {
        if (instance == null) instance = this;
    }
}