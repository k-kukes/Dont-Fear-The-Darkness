using UnityEngine;

public class NotePickup : MonoBehaviour
{
    public string noteSymbol;

    public int secretValue;

    public void ReadNote()
    {
        Debug.Log($"NOTE FOUND!");
        Debug.Log($"Symbol: {noteSymbol} | Number: {secretValue}");


    }
}