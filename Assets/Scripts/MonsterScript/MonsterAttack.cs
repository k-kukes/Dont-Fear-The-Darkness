using UnityEngine;
using UnityEngine.AI;

public class MonsterAttack : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2.5f;
    public float damage = 10f;
    public float attackCooldown = 1.5f;

    private float attackTimer = 0f;

    void Update()
    {
        if (player == null) return;

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && attackTimer <= 0)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
                attackTimer = attackCooldown;
            }
        }
    }
}