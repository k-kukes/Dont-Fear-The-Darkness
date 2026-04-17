using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public FlashlightController flashlightController;

    public float chaseRange = 35f;
    public float chaseSpeed = 4.5f;
    public float flashlightTriggerTime = 10f;

    private NavMeshAgent agent;
    private float flashlightTimer = 0f;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = chaseSpeed;
        }
    }

    void Update()
    {
        if (player == null || flashlightController == null || agent == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (flashlightController.IsFlashlightOn())
        {
            flashlightTimer += Time.deltaTime;

            if (flashlightTimer >= flashlightTriggerTime)
            {
                isChasing = true;
            }
        }
        else
        {
            flashlightTimer = 0f;
            isChasing = false;
            agent.isStopped = true;
            agent.ResetPath();
            return;
        }

        if (isChasing && distanceToPlayer <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}