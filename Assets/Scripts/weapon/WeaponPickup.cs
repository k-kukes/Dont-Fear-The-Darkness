using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public WeaponData weaponData;

    public void Interact()
    {
        PlayerAttack playerAttack = FindFirstObjectByType<PlayerAttack>();

        if (playerAttack != null && weaponData != null)
        {
            playerAttack.EquipWeapon(weaponData);
            gameObject.SetActive(false);
        }
    }
}