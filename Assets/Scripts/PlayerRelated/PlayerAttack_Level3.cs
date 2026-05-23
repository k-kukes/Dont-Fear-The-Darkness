using UnityEngine;

public class PlayerAttack_Level3 : MonoBehaviour
{
    public Camera playerCamera;

    private string currentWeaponName = "";
    private float currentDamage = 0f;
    private float currentDuration = 0f;
    private float currentRange = 0f;
    private float attackCooldown = 1f;
    private float attackTimer = 0f;
    private bool hasWeapon = false;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (hasWeapon)
        {
            currentDuration -= Time.deltaTime;

            if (currentDuration <= 0)
                RemoveWeapon();
        }

        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    public void EquipWeapon(WeaponData weapon)
    {
        currentWeaponName = weapon.weaponName;
        currentDamage = weapon.damage;
        currentDuration = weapon.duration;
        currentRange = weapon.attackRange;
        attackCooldown = weapon.attackCooldown;
        hasWeapon = true;

        Debug.Log("Equipped weapon: " + currentWeaponName);
    }

    void Attack()
    {
        if (!hasWeapon)
        {
            Debug.Log("No weapon equipped");
            return;
        }

        if (attackTimer > 0) return;

        attackTimer = attackCooldown;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, currentRange))
        {
            MonsterHealth_Level3 monsterHealth = hit.collider.GetComponentInParent<MonsterHealth_Level3>();

            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(currentDamage);
                Debug.Log("Hit monster with " + currentWeaponName);
            }
        }
    }

    void RemoveWeapon()
    {
        currentWeaponName = "";
        currentDamage = 0f;
        currentDuration = 0f;
        currentRange = 0f;
        hasWeapon = false;

        Debug.Log("Weapon expired");
    }
}