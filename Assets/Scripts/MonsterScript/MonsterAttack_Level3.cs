using UnityEngine;

public class MonsterAttack_Level3 : MonoBehaviour
{
    public Transform player;
    public float attackRange = 3f;
    public float damage = 20f;
    public float attackCooldown = 1.5f;

    private float attackTimer = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && attackTimer <= 0)
        {
            PlayerHealth_Level3 playerHealth = player.GetComponent<PlayerHealth_Level3>();

            if (playerHealth != null)
                playerHealth.TakeDamage(damage);

            if (animator != null)
                animator.SetTrigger("Attack");

            attackTimer = attackCooldown;
        }
    }
}